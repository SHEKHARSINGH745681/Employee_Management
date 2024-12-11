using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeAdminPortal.Repository.AuthRepo
{
    public class AuthRepoImpl : IAuthRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthRepoImpl(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> AuthenticateAsync(LoginDTO loginDto)
        {
            // Find the user by username (or email)
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                return null; // Return null if the user doesn't exist
            }

            // Check the password
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
            {
                return null; // Return null if the password is incorrect
            }

            var token = GenerateJwtToken(user);
            return token;
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> RegisterAsync(RegisterDTO registerDto)
        {
            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                return "Error: Passwords do not match.";
            }

            var user = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Username
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(registerDto.Role))
                {
                    if (!await _roleManager.RoleExistsAsync(registerDto.Role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(registerDto.Role));
                    }

                    await _userManager.AddToRoleAsync(user, registerDto.Role);
                }
                return "User registered successfully.";
            }

            return result.Errors.FirstOrDefault()?.Description ?? "An error occurred during user registration.";
        }
    }
}

    