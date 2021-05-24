using practice_falconsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft.Services
{
    public interface ILoginService
    {
        public LoginResponse Auth(LoginRequest model);
    }
}
