using Microsoft.AspNetCore.Identity;
using MoECommerce.Core.Interfaces.Services;
using Quizzely.Core.DataTransferObjects;
using Quizzely.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<UserDto?> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
            {
               var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
                if (result.Succeeded)
                {
                    return new UserDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.GetToken(user)
                    };
                }
            }
            return null;
        }

        public async Task<UserDto?> RegisterAsync(RegisterDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is not null) throw new Exception("Email Exists");

            var appuser = new IdentityUser
            {
                Email = dto.Email,
                UserName = dto.UserName,
            };

            var result = await _userManager.CreateAsync(appuser, dto.Password);

            if (!result.Succeeded) throw new Exception("Error");
            return new UserDto
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Token = _tokenService.GetToken(appuser)
            };
        }
    }
}
