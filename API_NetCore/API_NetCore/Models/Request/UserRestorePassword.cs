namespace OKEA.Library.Models.Request
{
    public class UserRestorePassword
    {
        public string ActivationCode { get; set; }
        public string Password { get; set; }
    }
}
