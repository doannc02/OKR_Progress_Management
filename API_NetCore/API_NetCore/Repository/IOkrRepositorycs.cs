using API_NetCore.Models.DataTranferObject;
using Microsoft.AspNetCore.Mvc;
using OKEA.Library.Models.Request;
using OKEA.Library.Models.ViewModels;

namespace API_NetCore.Repository
{
    public interface  IOkrRepository 
    {
        public Task<List<MemberOkrViewModel>> GetMemberOkrList(OkrFilterRequest okrFilter);
        Task<List<MemberOkrViewModel>> GetAllMenberCheckIn(string DepartmentStruct);
        public Task<MemberOkrViewModel> GetById(int id);
        public Task<DTO_User> GetByEmail(string email);
        public Task<int> AddUser(DTO_User user);
        public Task UpdateUser(int id, DTO_User user);
        public Task DeleteUser(int id);
    }
}
