using API_NetCore.Models.DataTranferObject;
using API_NetCore.Models.Entitiess;
using OKEA.Library.Models.Request;
using System.Runtime.CompilerServices;

namespace API_NetCore.Repository
{
    public interface IUserRepository
    {
        public Task<List<DTO_User>> GetAllUser();
        public Task<DTO_User> GetById(int id);
        public Task<DTO_User> GetByEmail(string email);
        public Task<User> AddUser(UserRegister user);
        public Task<bool> UpdateUser(string email, string  user);
        public Task DeleteUser(int id);
        public Task<string> Register(UserRegister user);
        
        public Task<object> Login(AccountLogin acc);
    }
}
