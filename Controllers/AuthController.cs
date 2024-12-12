using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.IRepo;
using EmployeeAdminPortal.Repository.CrudRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{

    [Route("Api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _IAuthRepo;

        public AuthController(IAuthRepo iAuthRepo, ApplicationDbContext dbContext)
        {
            _IAuthRepo = iAuthRepo;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] LoginDTO loginDto)
        {
            var authResponse = await _IAuthRepo.AuthenticateAsync(loginDto);
            if (authResponse == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok(authResponse);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterDTO registerDto)
        {
            var result = await _IAuthRepo.RegisterAsync(registerDto);
            if (result == "User registered successfully.")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}


