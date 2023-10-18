using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OKEA.Library.Models.Request;
using API_NetCore.Models.Entitiess;
using API_NetCore.Repository;
using API_NetCore.Service;
using API_NetCore.Models.Request;
using API_NetCore.Helpers;
using OKEA.Library.Models.Filter;
using System.Globalization;
using System.Security.Cryptography;
using OKEA.Service.Main.API.Controllers.Base;

namespace API_NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AuthController
    {
        private readonly IUserRepository _repo;
        private IUserService _userService;

        public UserController(IUserRepository repo) { 
            _repo = repo;
        }
        //lấy dữ liệu tất cả các user
        [HttpGet]
        [AllowAnonymous]
        [Route("/api/[controller]/GetAll")]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            try
            {
                var users = await _repo.GetAllUser();

                // Tính toán chỉ trang cần lấy dựa trên page và pageSize
                var startIndex = (page - 1) * pageSize;
                var endIndex = startIndex + pageSize;

                // Lấy danh sách người dùng trang cần lấy
                var usersPage = users.Skip(startIndex).Take(pageSize);

                // Lấy tổng số bản ghi
                var totalRecords = users.Count();

                // Trả về thông tin phân trang bao gồm tổng số bản ghi và dữ liệu trang cần lấy
                var result = new
                {
                    TotalRecords = totalRecords,
                    Data = usersPage
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //lấy dữ liệu 1 user 
        [HttpPost]
        [Route("/api/[controller]/Add")]
        public async Task<IActionResult> Add(UserRegister request)
        {
            try
            {
                var user = await _repo.AddUser(request);
                return Ok(user);

            }catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        //update
        
        [HttpPost]
        [Route("/api/[controller]/Update")]
        public async Task<IActionResult> Update(TestMutationUpdate _user )
        {
            try
            {
                var user = await _repo.UpdateUser(_user.email, _user.name);
                string body = ("cmm");
                _ = Task.Run(() => EmailHelper.SendMail("Xác thực đăng kí tài khoản OKR!", body, "sillver47108@gmail.com", "doan.nguyencong@apuscorp.com"));
                return Ok(user);

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        //create
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/[controller]/register")]
        public async Task<IActionResult> Register(UserRegister u)
        {
            try {
                var userRegister = await _repo.Register(u);
                return Ok(userRegister);
                
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/[controller]/login")]
        public async Task<IActionResult> Login(AccountLogin acc)
        {
            try
            {
                var result = await _repo.Login(acc);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
