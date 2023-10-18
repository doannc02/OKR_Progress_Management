using API_NetCore.Repository;
using Microsoft.AspNetCore.Mvc;
using OKEA.Library.Models.Request;
using OKEA.Service.Main.API.Controllers.Base;

namespace API_NetCore.Controllers;

    [Route("api/[controller]")]
    [ApiController]
public class OkrController : AuthController
    {
    private readonly IOkrRepository _repo;

    public OkrController(IOkrRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    [Route("/api/[controller]")]
    public async Task<IActionResult> GetAll(OkrFilterRequest okrFilter)
    {
        try
        {
            var userFind = GetCurrentUser();
            if (userFind == null)
            {
                return Unauthorized();
            }
            var okrs = await _repo.GetMemberOkrList(okrFilter);
            return Ok((okrs));
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    }

