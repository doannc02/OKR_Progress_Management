using API_NetCore.Models.DataTranferObject;
using API_NetCore.Models.Entitiess;
using AutoMapper;

namespace API_NetCore.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() { 
        CreateMap<User, DTO_User>().ReverseMap();
        }
    }
}
