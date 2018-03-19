using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Services
{
    class LoginService
    {
        public static bool Login(string login, string password)
        {
            if (login == "admin")
                if (password == "admin")
                    return true;
                else
                    return false;
            return false;
        }
    }
}
