namespace API_NetCore.Models.Response
{
    public class DisplayControlRegisterResponse<T>
    {
        public T RoleOfUser { get; set; }
        public T DepartmentViewModel { get; set; }

    }
}
