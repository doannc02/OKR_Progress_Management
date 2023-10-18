using API_NetCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OKEA.Service.Main.API.Controllers.Base;

namespace API_NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegisterController : AuthController
    {
        private readonly IRegisterRepository<object> register;
        public RegisterController(IRegisterRepository<object> register) => this.register = register;
        [HttpGet]
        public async Task<IActionResult> GetInfoDisplayControl()
        {
            try
            {
                var dt = await register.GetInfoDisplayControl();
                return Ok(dt);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
