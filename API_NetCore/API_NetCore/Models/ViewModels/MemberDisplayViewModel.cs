namespace OKEA.Library.Models.ViewModels
{
    public class MemberDisplayViewModel
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsManager { get; set; }
        public string Avatar { get; set; }
    }
}
