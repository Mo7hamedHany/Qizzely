﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.DataTransferObjects
{
    public class UserDto
    {
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
