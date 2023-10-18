using API_NetCore.Authorization;
using API_NetCore.Helpers;
using API_NetCore.Models.Entitiess;
using API_NetCore.Models.Request;
using API_NetCore.Models.Response;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Extensions.Options;

namespace API_NetCore.Service
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
    public class UserService
    {
        private OKEAContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public UserService(
            OKEAContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }
         

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.FullName == model.Username);

            // validate
            //if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
            //    throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
