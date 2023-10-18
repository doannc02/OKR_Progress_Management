using Microsoft.AspNetCore.Http;
using API_NetCore.Models.Entitiess;

namespace OKEA.Library.Models.Request
{
    public class StoreInsert
    {
        public Store Product { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
