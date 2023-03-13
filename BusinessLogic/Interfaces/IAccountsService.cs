﻿using Core.Dtos.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task<IdentityUser> Get(string id);
        Task Login(LoginDto dto);
        Task Register(RegisterDto dto);
        Task Logout();

        // others...
    }
}
