
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;

using API.Entities;
using API.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
            if (await EmailExists(registerDto.Email)) return BadRequest("Email is already in use");
            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = registerDto.Username.ToLower(),
                FirstName = registerDto.Firstname,
                LastName = registerDto.LastName,
                Email = registerDto.Email.ToLower(),
                RoleID = 2,
                CompanyID = registerDto.CompanyID,
                LocationID = registerDto.LocationID,
                RegionID = registerDto.RegionID,
                Phone = registerDto.Phone,
                PasswordReset = false,
                Status = 0,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                CreatedDate = new DateTime()
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await context.Users
            .FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            if (user.Status == 2) return Unauthorized("ACCESS DENIED");
            if (user.Status == 0) return Unauthorized("Pending approval");

            return new UserDto
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };

        }

        private async Task<bool> UserExists(string username)
        {

            return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }

        private async Task<bool> EmailExists(string email)
        {

            return await context.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower());
        }

    }


}