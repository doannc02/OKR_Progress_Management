using API_NetCore.Models.DataTranferObject;
using API_NetCore.Models.Entitiess;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OKEA.Library.Models.Filter;
using OKEA.Library.Models.Request;
using OKEA.Library.Models.ViewModels;
using System.Linq;
using System.Security.Cryptography;


namespace API_NetCore.Repository
{
    public class OkrRepository : IOkrRepository
    {
        private readonly OKEAContext _context;

        public OkrRepository(OKEAContext context)
        {
            _context = context;
        }

        public Task<int> AddUser(DTO_User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DTO_User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<MemberOkrViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MemberOkrViewModel>> GetMemberOkrList(OkrFilterRequest okrFilter)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == okrFilter.UserId);
            var data = new List<MemberOkrViewModel>();
            var  deparmentFInd = await _context.DepartmentUsers.FirstOrDefaultAsync(u => u.Id == okrFilter.UserId);
            var manager = new List<User>();
            var childrenMembers = new List<User>();
            
            if (deparmentFInd != null && deparmentFInd.IsActived)
            {
                var testData = await GetAllMenberCheckIn(deparmentFInd.DepartmentStructure);
                var structure = deparmentFInd.DepartmentStructure.Split(".");
                var childrenDepartmentFinds = await _context.Departments.Where(i => i.IsActived == true && i.ParentId == deparmentFInd.Id).ToListAsync();
                if (structure != null && structure.Any())
                {
                    foreach (var item in structure)
                    {
                        if (!item.Equals("0"))
                        {
                            // var managerOfDepartmentFind = await _unitOfWork.DepartmentUser.Filter(new DepartmentUserFilter() { DepartmentId = int.Parse(item), IsActived = true, IsManager = true });
                        
                            
                                var managerOfDepartmentFind = await _context.DepartmentUsers.Where(i => i.DepartmentId == int.Parse(item) && i.IsActived == true && i.IsManager == true ).ToListAsync();

                                if (managerOfDepartmentFind != null && managerOfDepartmentFind.Any())
                                {
                                    foreach (var manage in managerOfDepartmentFind.ToList())
                                    {
                                        var managerInformation = await _context.Users.FirstOrDefaultAsync(u => u.Id == manage.UserId && u.IsActived);

                                        if (managerInformation != null)
                                        {
                                            manager.Add(managerInformation);
                                        }
                                    }
                                
                            }

                        }
                    }
                }
                if (childrenDepartmentFinds != null && childrenDepartmentFinds.Any())
                {
                    foreach (var childrenDepartmentFind in childrenDepartmentFinds)
                    {
                        var childDepartmentFinds = await _context.Departments.Where(i => i.IsActived == true && i.DepartmentStructure == childrenDepartmentFind.Id.ToString()).ToListAsync();

                        if (childDepartmentFinds != null && childDepartmentFinds.Any())
                        {
                            foreach (var childDepartmentFind in childDepartmentFinds)
                            {
                                var childDepartmentUserFinds = await _context.DepartmentUsers.Where(i => i.IsActived == true && i.DepartmentId == childDepartmentFind.Id).ToListAsync();

                                if (childDepartmentUserFinds != null && childDepartmentUserFinds.Any())
                                {
                                    foreach (var childDepartmentUserFind in childDepartmentUserFinds)
                                    {
                                        var childUserFind = await _context.Users.FindAsync(childDepartmentUserFind.UserId);

                                        if (childUserFind != null)
                                        {
                                            childrenMembers.Add(childUserFind);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            manager = manager.Distinct().ToList();
            var memberInDepartment = await _context.DepartmentUsers.Where(i => i.IsActived == true && i.DepartmentId == user.DepartmentId && i.IsManager == false).ToArrayAsync();
            var memberList = new List<User>();

            if (memberInDepartment != null && memberInDepartment.Any())
            {
                foreach (var member in memberInDepartment)
                {
                    var memberFind = await _context.Users.FirstOrDefaultAsync(i => i.Id == member.UserId);

                    if (memberFind != null && memberFind.IsActived)
                    {
                        memberList.Add(memberFind);
                    }
                }
            }

            // tổng hợp lại danh sách quản lý và member
            var members = new List<User>();
            members.AddRange(manager);
            members.AddRange(memberList);
            members.AddRange(childrenMembers);
            members = members.Distinct().Where(x => x.Id != 0 && !string.IsNullOrEmpty(x.Email)).ToList();
            var allowCheckIn = manager.FirstOrDefault(x => x.Id == user.Id) != null;

            if (!string.IsNullOrEmpty(okrFilter.UserEmail))
            {
                members = _context.Users.Where(x => x.Email.Contains(okrFilter.UserEmail)).ToList();
            }

            if (members != null && members.Any())
            {
                foreach (var member in members)
                {
                    okrFilter.UserId = member.Id;
                    var memberOkrViewModel = await GetMemberOkrViewModel(okrFilter);

                    if (memberOkrViewModel != null)
                    {
                        memberOkrViewModel.AllowCheckIn = allowCheckIn;
                        data.Add(memberOkrViewModel);
                    }
                }
            }

            return (data);
        }
        public async Task<List<MemberOkrViewModel>> GetAllMenberCheckIn(string DepartmentStruct)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-NFH2VNK\\SQLEXPRESS;Initial Catalog=OKEA;Integrated Security=True"))
            {
                try
                {
                    List<MemberOkrViewModel> MemberOkrViewModels = new List<MemberOkrViewModel>();
                    List<MemberObjectiveViewModel> MemberObjectiveViewModels = new List<MemberObjectiveViewModel>();
                    List<MemberKeyResultViewModel> MemberKeyResultViewModels = new List<MemberKeyResultViewModel>();
                    List<MemberKeyResultActionViewModel> MemberKeyResultActionViewModels = new List<MemberKeyResultActionViewModel>();

                    string strSql = @"
                        select
	                        t.value DepartmentId
                        into #tbl_DepartmentId
                        from string_split(@struct, '.') t
                        ;

                        select
	                        t.*
                        into #tbl_getAllDepartment
                        from Department t
	                        inner join #tbl_DepartmentId f
		                        on t.Id = f.DepartmentId
                        union
                        select
	                        t.*
                        from Department t
                        where
	                        t.DepartmentStructure like @struct + '%'
                        ;

                        select 
	                        ok.Id,
	                        u.Id UserId,
	                        u.FullName,
	                        u.Email,
                            u.Avatar,
	                        ok.Name,
	                        u.Role,
                            f.UserRoleName,
	                        u.DepartmentId,
	                        u.DepartmentName,
	                        ok.OkrPercent,
	                        ok.OkrType,
	                        ok.Status,
                            f.IsManager,
                            t.DepartmentStructure,
	                        (case
		                        when LEN(t.DepartmentStructure) < LEN(@struct) then 0
		                        when LEN(t.DepartmentStructure) = LEN(@struct) and f.IsManager = 0 then 1
		                        when LEN(t.DepartmentStructure) = LEN(@struct) and f.IsManager = 1 then 0
		                        when LEN(t.DepartmentStructure) > LEN(@struct) then 1
	                        end) AllowCheckIn
                        from #tbl_getAllDepartment t
	                        inner join DepartmentUser f
		                        on t.Id = f.DepartmentId
	                        inner join [User] u
		                        on f.UserId = u.Id
	                        inner join Okr ok
		                        on u.Id = ok.UserId
                        order by u.DepartmentId
                        ;

                        drop table #tbl_DepartmentId;
                        drop table #tbl_getAllDepartment;
                        ;
                        ";
                    var results = await connection.QueryAsync<MemberOkrViewModel>(strSql, new { @struct = DepartmentStruct });
                   ;
                    MemberOkrViewModels = results.ToList();

                    return results.ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        private async Task<MemberOkrViewModel> GetMemberOkrViewModel(OkrFilterRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == request.UserId.Value);

            if (user == null)
            {
                return null;
            }

            var viewModel = new MemberOkrViewModel();
            var objectiveViewModels = new List<MemberObjectiveViewModel>();
            var okr = new Okr();

            if (request.OkrId == null)
            {
                var okrData = await _context.Okrs.Where(i => i.IsActived == true && i.UserId == user.Id).ToArrayAsync();

                if (okrData != null && okrData.Any())
                {
                    okr = okrData.FirstOrDefault();
                }
            }
            else
            {
                var okrData = await _context.Okrs.FirstOrDefaultAsync(i => i.Id == request.OkrId.Value);

                if (okrData != null)
                {
                    okr = okrData;
                }
            }

            if (okr != null && okr.Id > 0)
            {
                var objectives = await _context.Objectives.Where(i => i.IsActived == true && i.UserId == request.UserId && i.OkrId == okr.Id ).ToArrayAsync();

                if (objectives != null && objectives.Any())
                {

                    foreach (var objective in objectives)
                    {
                        var keyResults = await _context.KeyResults.Where(i => i.IsActived == true && i.ObjectiveId == objective.Id && i.UserId == request.UserId).ToArrayAsync();
                        var keyResultViewModels = new List<MemberKeyResultViewModel>();

                        if (keyResults != null && keyResults.Any())
                        {
                            foreach (var keyResult in keyResults)
                            {
                                var keyResultActionViewModels = new List<MemberKeyResultActionViewModel>();
                                var keyResultActions = await _context.KeyResultActions.Where(i => i.IsActived == true && i.KeyResultId == keyResult.Id && i.UserId == request.UserId).ToArrayAsync();

                                if (keyResultActions != null && keyResultActions.Any())
                                {
                                    foreach (var keyResultAction in keyResultActions)
                                    {
                                        var keyResultActionViewModel = new MemberKeyResultActionViewModel()
                                        {
                                            Id = keyResultAction.Id,
                                            ActionName = keyResultAction.ActionName,
                                            ActionPercent = keyResultAction.ActionPercent,
                                            KeyResultId = keyResultAction.KeyResultId,
                                            KeyResultName = keyResultAction.KeyResultName,
                                            QuarterId = (long)keyResultAction.QuarterId,
                                            QuarterName = keyResultAction.QuarterName,
                                            QuarterData = keyResultAction.QuarterData,
                                            UserId = request.UserId
                                        };

                                        keyResultActionViewModels.Add(keyResultActionViewModel);
                                    }
                                }

                                var keyResultViewModel = new MemberKeyResultViewModel()
                                {
                                    Id = keyResult.Id,
                                    KeyResultName = keyResult.KeyResultName,
                                    KeyResultPercent = keyResult.KeyResultPercent,
                                    ObjectiveId = keyResult.ObjectiveId,
                                    QuarterId = (long)keyResult.QuarterId,
                                    QuarterName = keyResult.QuarterName,
                                    QuarterData = keyResult.QuarterData,
                                    UserId = request.UserId,
                                    KeyResultActions = keyResultActionViewModels
                                };

                                keyResultViewModels.Add(keyResultViewModel);
                            }
                        }

                        var objectiveViewModel = new MemberObjectiveViewModel()
                        {
                            Id = objective.Id,
                            UserId = objective.UserId,
                            ObjectiveName = objective.ObjectiveName,
                            ObjectivePercent = objective.ObjectivePercent,
                            ObjectiveType = (OKEA.Library.Models.Enums.ObjectiveType?)objective.ObjectiveType,
                            OkrId = objective.OkrId,
                            OkrName = objective.OkrName,
                            Status = (OKEA.Library.Models.Enums.Status?)objective.Status,
                            KeyResults = keyResultViewModels
                        };

                        objectiveViewModels.Add(objectiveViewModel);
                    }
                }

                viewModel.Id = okr.Id;
                viewModel.OkrName = okr.Name;
                viewModel.FullName = user.FullName;
                viewModel.Email = user.Email;
                viewModel.Role = user.Role;
                viewModel.DepartmentId = user.DepartmentId;
                viewModel.DepartmentName = user.DepartmentName;
                viewModel.OKrPercent = okr.OkrPercent;
                viewModel.OkrType = okr.OkrType;
                viewModel.OkrStatus = (OKEA.Library.Models.Enums.Status?)okr.Status;
                viewModel.UserId = okr.UserId;
                viewModel.Objectives = objectiveViewModels;
            }

            return viewModel;
        }

        public Task UpdateUser(int id, DTO_User user)
        {
            throw new NotImplementedException();
        }
    }
}
