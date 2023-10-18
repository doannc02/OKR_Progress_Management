

using API_NetCore.Models.Response;

namespace API_NetCore.Repository
{
    public interface IRegisterRepository<T>
    {
        public Task<DisplayControlRegisterResponse<T>> GetInfoDisplayControl();
        public Task<string> ExcuteForgot(string email);
        public Task<object> ActivationAccount(string activationCode);
    }
}
