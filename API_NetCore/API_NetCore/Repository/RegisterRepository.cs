using API_NetCore.Models.Entitiess;
using API_NetCore.Models.Response;
using Microsoft.EntityFrameworkCore;
using OKEA.Library.Models.ViewModels;
using System.Collections.Generic;

namespace API_NetCore.Repository
{
    public class RegisterRepository : IRegisterRepository<object>

    {
        private readonly OKEAContext context;
        public RegisterRepository(OKEAContext context)
        {
            this.context = context;
        }
        public Task<object> ActivationAccount(string activationCode)
        {
            throw new NotImplementedException();
        }

        public Task<string> ExcuteForgot(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<DisplayControlRegisterResponse<object>> GetInfoDisplayControl()
        {
            try
            {
                var response = new DisplayControlRegisterResponse<object>();

                var roleData = await context.RoleOfUsers
                    .Where(u => u.IsActived == true)
                    .ToListAsync();

                var departmentProjectTypeFind = await context.DepartmentTypes
                    .Where(u => u.Type == "Project")
                    .FirstOrDefaultAsync();

                long projectIdFind = departmentProjectTypeFind?.Id ?? 0;

                var result = await context.Departments
                    .Where(u => u.IsActived == true && u.DepartmentTypeId == projectIdFind)
                    .ToListAsync();

                var data = result
                    .Where(department => department.ParentId != 0)
                    .Select(department => new DepartmentViewModel
                    {
                        Id = department.Id,
                        Name = department.Name,
                        ParentId = department.Id,
                        ParentName = department.Name
                    })
                    .ToList();

                response.DepartmentViewModel = data;
                response.RoleOfUser = roleData;

                return response;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi theo nhu cầu của bạn, ví dụ:
                var errorResponse = new DisplayControlRegisterResponse<object>
                {
                    RoleOfUser = null,
                    DepartmentViewModel = null,
                };
                // Log lỗi hoặc thông báo lỗi nếu cần
                // throw new Exception("Xử lý lỗi: " + ex.Message);
                return errorResponse;
            }
        }

    }
}
