using Quizzely.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto?> LoginAsync(LoginDto dto);

        Task<UserDto?> RegisterAsync(RegisterDto dto);
    }
}
