﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IUsersDAL
    {
        bool RegisterNewUser(UserModel newUser);
        UserModel GetUser(string username, string password);
        UserModel GetUser(string username);   
    }
}
