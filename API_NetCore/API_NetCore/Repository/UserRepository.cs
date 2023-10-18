using API_NetCore.Common;
using API_NetCore.Common.Provider;
using API_NetCore.Helpers;
using API_NetCore.Models.DataTranferObject;
using API_NetCore.Models.Entitiess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OKEA.Library.Models.Cache;
using OKEA.Library.Models.Enums;
using OKEA.Library.Models.Filter;
using OKEA.Library.Models.Request;
using OKEA.Library.Models.Response;
using OKEA.Service.Main.API.Controllers.Base;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using static API_NetCore.Common.Constants;

namespace API_NetCore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly OKEAContext _context;
        private readonly IMapper _mapper;
        private readonly CacheProvider _cacheProvider;
        public UserRepository(OKEAContext context, IMapper mapper, CacheProvider cacheProvider)
        {
            _context = context;
            _mapper = mapper;
            _cacheProvider = cacheProvider;
        }

        public async Task<User> AddUser(UserRegister req)
        {
            var user = new User();
            user.FullName = req.User.FullName;
            var department = _context.Departments.FirstOrDefault(d => d.Id == req.User.DepartmentId);
            if (department != null)
            {
                user.DepartmentName = department.Name;
            }
            user.Role = req.User.Role;
            var newUser = _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return newUser.Entity;
        }

        public async Task DeleteUser(int id)
        {
            var u = await _context.Users!.FirstOrDefaultAsync(u => u.Id == id);

            _context.Users.Remove(u);
            
           
        }

        public async Task<List<DTO_User>> GetAllUser()
        {
           var users = await _context.Users!.ToListAsync();
            return _mapper.Map<List<DTO_User>>(users);
        }

        public async Task<DTO_User> GetByEmail(string email)
        {
            var user = await _context.Users!.FirstOrDefaultAsync(u => u.Email == email);
            return _mapper.Map<DTO_User>(user);
           
        }

        public Task<DTO_User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(string email , string  user)
        {
            var u = _context.Users!.FirstOrDefault(u => u.Email == email);
            if (u != null)
            {
                u.FullName = user;
            }
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<string> Register(UserRegister user)
        {
            try
            {
                var entity = user.User;
                var departmentFind = await _context.Departments.FindAsync(user.User.DepartmentId);

                if (departmentFind == null)
                {
                    return  ("Không tìm thấy phòng ban tương ứng!");
                }

                if (entity == null || string.IsNullOrEmpty(entity.Email) || string.IsNullOrEmpty(entity.FullName) || string.IsNullOrEmpty(entity.Password))
                {
                    return ("Dữ liệu không được để trống!");
                }

                //if (!StringHelper.IsValidEmail(entity.Email) || !entity.Email.EndsWith(Regular.EmailEndWith))
                //{
                //    return Ok(ErrorMessage("Email không đúng định dạng hoặc không phải email ominext!"));
                //}

                var userFind = await _context.Users.Where(u => u.Email == user.User.Email ).ToListAsync();

                if (userFind != null && userFind.Any())
                {
                    return "Email đã tồn tại trên hệ thống!";
                }

                string activationCode = "";

                while (true)
                {
                    activationCode = StringProvider.RandomString(20);
                    var codeFind = await _context.Users.Where(u => u.ActivationCode == activationCode).ToListAsync();

                    if (codeFind == null || !codeFind.Any())
                    {
                        break;
                    }
                }

                var departmentStructure = "0";

                if (departmentFind.ParentId > 0)
                {
                    var parent1 = await _context.Departments.FindAsync(departmentFind.ParentId);

                    if (parent1 != null)
                    {
                        var parent2 = await _context.Departments.FindAsync(parent1.ParentId); 

                        if (parent2 != null)
                        {
                            var parent3 = await _context.Departments.FindAsync(parent2.ParentId);

                            if (parent3 != null)
                            {
                                departmentStructure += $".{parent3.Id}.{parent2.Id}.{parent1.Id}";
                            }
                            else
                            {
                                departmentStructure += $".{parent2.Id}.{parent1.Id}";
                            }
                        }
                        else
                        {
                            departmentStructure += $".{parent1.Id}";
                        }
                    }
                }

                if (entity.RoleOfUserId != null && entity.RoleOfUserId > 0)
                {
                    var roleFind = await _context.RoleOfUsers.FindAsync(entity.RoleOfUserId.Value);

                    if (roleFind != null)
                    {
                        entity.Role = roleFind.Role;
                    }
                }

                entity.FullName = entity.FullName.ToLower();
                var textInfo = new CultureInfo("en-US", false).TextInfo;
                entity.FullName = textInfo.ToTitleCase(entity.FullName);
                entity.Email = entity.Email.ToLower();
                entity.ActivationCode = activationCode;
                entity.IsActived = false;
                entity.Password = HashProvider.CreateMD5(entity.Password);
                entity.DepartmentName = departmentFind.Name;
                entity.CurrentStar = 0;
                entity.GivenStar = 0;
                var id = await _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync();

                if (id == null )
                {
                    return "Đăng ký người dùng thất bại! Vui lòng liên hệ với quản trị viên!";
                }

                var departmentUser = new DepartmentUser()
                {
                    DepartmentId = departmentFind.Id,
                    DepartmentName = departmentFind.Name,
                    StartDate = DateTime.Now,
                    IsActived = false,
                    UserId = id.Entity.Id,
                    UserEmail = entity.Email,
                    UserFullName = entity.FullName,
                    DepartmentStructure = departmentStructure
                };

                var departmentUserId = await _context.DepartmentUsers.AddAsync(departmentUser);

                if (departmentUserId == null)
                {
                    return "Đăng ký người dùng thất bại! Vui lòng liên hệ với quản trị viên!";
                }

                string title = "Email xác thực tài khoản OKR";
                string body = GenerateEmailBody(user.User.FullName, $"Register/PrepareActivationAccount/?activationCode={activationCode}");
                _ = Task.Run(() => EmailHelper.SendMail(title, body, user.User.Email, user.User.FullName));
                return "Đăng ký tài khoản thành công! Vui lòng kiểm tra email để xác thực tài khoản!";
            }
            catch (Exception ex)
            {
               
                return (ex.Message);
            }
        }


        //login
        public async Task<object> Login(AccountLogin userLogin)
        {
            try
            {
                if (string.IsNullOrEmpty(userLogin.LoginName) || string.IsNullOrEmpty(userLogin.Password))
                {
                  return  new
                    {
                        Errormessage = "Email và mật khẩu không được để trống!",

                    };
                }

              //  var userFilter = await _context.Users.FirstOrDefaultAsync(u => u.Email == userLogin.LoginName);
              var userFilter = await  _context.Users.FirstOrDefaultAsync(u => u.Email == userLogin.LoginName);

                if (userFilter == null || !userFilter.Password.Equals(HashProvider.CreateMD5(userLogin.Password)))
                {
                    return "Email hoặc mật khẩu không chính xác!";
                }

                var user = userFilter;

                if (user == null || !user.IsActived)
                {
                    return new
                    {
                        Errormessage = "Tài khoản đang bị khoá hoặc chưa kích hoạt!"

                    };
                }
                

                string token = Cookies.KeyUser + Guid.NewGuid().ToString();
                var expireTime = DateTime.Now.AddHours(Regular.TokenExpireTime);
                var oldTokenFind = await _context.AccountTokens.FirstOrDefaultAsync(t => Convert.ToInt64(t.AccountId) == Convert.ToInt64(user.Id) && t.Type == 2);

                /*
                 * {
  "loginName": "hieund@ominext.com",
  "password": "123123"
}
                 */



                if (oldTokenFind != null)
                {
                    var oldToken = oldTokenFind;

                    if (oldToken != null)
                    {
                        oldToken.Token = token;
                        oldToken.CreatedAt = DateTime.Now;
                        oldToken.ExpiredAt = expireTime;
                        oldToken.Type = 2;

                        //  var rst = await _unitOfWork.AccountToken.Update(oldToken.AccountId, oldToken, TokenType.User);
                        //tim token cu va update 
                        var find = await _context.AccountTokens.FirstAsync(u => u.Id == oldToken.Id && u.Type == 2);

                        if (find != null)
                        {
                            var rst =  _context.AccountTokens.Update(oldToken);
                            await _context.SaveChangesAsync();
                            if (rst == null)
                            {
                                return "Đăng nhập thất bại! Không thể khởi tạo token người dùng!";
                            }
                        }

                    }
                    else
                    {
                        var newT = new AccountToken
                        {
                            AccountId = user.Id,
                            Token = token,
                            CreatedAt = DateTime.Now,
                            ExpiredAt = expireTime,
                            Type = 2
                        };
                        var result = await _context.AccountTokens.AddAsync(newT);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    var newT = new AccountToken
                    {
                        AccountId = user.Id,
                        Token = token,
                        CreatedAt = DateTime.Now,
                        ExpiredAt = expireTime,
                        Type = 2
                    };
                    var result = await _context.AccountTokens.AddAsync(newT);
                    await _context.SaveChangesAsync();
                }

                // xóa cache cũ
                if (oldTokenFind != null)
                {

                     _cacheProvider.Delete(oldTokenFind.Token);
                }

                // Người dùng và phòng ban
                var departmentUsers = await _context.DepartmentUsers.Where(u => u.UserId == user.Id).ToListAsync();
                var department = await _context.Departments.FirstOrDefaultAsync(u => u.Id == user.DepartmentId);
                var DepartmentUserCaches = new List<DepartmentUserCache>();
                var isManager = false;

                if (departmentUsers != null )
                {
                    foreach (var departmentUser in departmentUsers)
                    {
                        var departmentFind = await _context.Departments.FirstOrDefaultAsync(u => u.Id == departmentUser.DepartmentId);

                        DepartmentUserCache dpmUser = new DepartmentUserCache()
                        {
                            DepartmentId = departmentUser.DepartmentId,
                            DepartmentName = departmentUser.DepartmentName,
                            UserRoleId = departmentUser.UserRoleId,
                            UserRoleName = departmentUser.UserRoleName,
                            IsManager = departmentUser.IsManager,
                            ParentId = departmentFind?.ParentId,
                            DepartmentStructure = departmentUser.DepartmentStructure
                        };

                        DepartmentUserCaches.Add(dpmUser);
                    }

                    isManager =  departmentUsers.Where(x => (bool)x.IsManager).Any();
                }

                // lưu token vào cache để lấy ra nhanh hơn
                _cacheProvider.Set(token, new UserCache
                {
                    UserId = user.Id,
                    Gender = (Gender)user.Gender,
                    Email = user.Email,
                    FullName = user.FullName,
                    CurrentStar = user.CurrentStar,
                    UserRole = user.UserRole,
                    DepartmentId = user.DepartmentId,
                    DepartmentName = user.DepartmentName,
                    DepartmentUserJson = JsonConvert.SerializeObject(DepartmentUserCaches),
                    DepartmentStructure = department.DepartmentStructure,
                    IsManager = isManager
                }, expireTime);

                user.Password = null;

                var responseData = new LoginResponse<User>()
                {
                    User = user,
                    Token = token,
                    IsManager = isManager
                };


                return responseData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private static string GenerateEmailBody(string fullName, string registerConfirmationUrl)
        {
            string htmlStr = "<div style='width: 800px; margin: 50px 0 0 50px;'>";
            htmlStr += "<div style='width: 100%; padding: 50px; background-color: #002d93; color: #fff; margin-top: 10px; border-radius: 20px; font-weight: bold; font-size: 2rem;'>";
            htmlStr += $"<h1 style='margin-bottom: unset;'>Xin chào <span>{fullName}</span>!</h1>";
            htmlStr += "<hr />";
            htmlStr += "<p>Đây là email xác nhận rằng bạn đã đăng ký thành công vào hệ thống của chúng tôi!</p>";
            htmlStr += "<p>Vui lòng click vào nút bên dưới để hoàn tất việc đăng ký</p>";
            htmlStr += "<div style='width: 100%; height: auto; text-align: center;'>";
            htmlStr += $"<a href='{registerConfirmationUrl}' style='color:#fff; background-color: #93c; padding: 10px 50px; border: 1px solid #fff; border-radius: 15px; text-decoration: none;'>Hoàn tất đăng ký</a>";
            htmlStr += "</div>";
            htmlStr += "</div>";
            htmlStr += "</div>";
            return htmlStr;
        }
    }
}
