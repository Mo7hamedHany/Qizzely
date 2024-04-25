﻿

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Interfaces.Services
{
    public interface ITokenService
    {
        string GetToken(IdentityUser user);
    }
}
