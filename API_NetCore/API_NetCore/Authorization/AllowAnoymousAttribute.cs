namespace API_NetCore.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnoymousAttribute : Attribute
    {
    }
}
