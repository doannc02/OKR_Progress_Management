using API_NetCore.Models.Entitiess;

namespace API_NetCore.Models.Response
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string  Role { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = (int)user.Id;
            Username = user.FullName;

            Role = user.Role;
            Token = token;
        }
    }
}
