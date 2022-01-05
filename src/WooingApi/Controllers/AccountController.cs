using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WooingApi.Data;
using WooingApi.Dtos;
using WooingApi.Models;

namespace WooingApi.Controllers;
public class AccountController : BaseApiController
{
    private readonly DataContext _dataContext;
    public AccountController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        if(await this.UserExists(registerDto.UserName))
        {
            return BadRequest("User already exists!");
        }
        using var hmac = new HMACSHA512();
        var user = new User
        {
            UserName = registerDto.UserName.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        _dataContext.Users.Add(user);
        await _dataContext.SaveChangesAsync();
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
         var user = await _dataContext.Users.FirstOrDefaultAsync(u=>u.UserName == loginDto.UserName);
         if(user == null)
         {
             return Unauthorized("Invalid User");
         }
         var hmac = new HMACSHA512(user.PasswordSalt);
         var userHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
         
         for(int i = 0; i < userHash.Length; i++)
         {
             if(userHash[i] != user.PasswordHash[i])
             {
                return Unauthorized("Invalid Password");
             }
         }

         return Ok(user);
    }

    private async Task<bool> UserExists(string userName)
    {
        return await _dataContext.Users.AnyAsync(u=>u.UserName.Equals(userName));
    }
}