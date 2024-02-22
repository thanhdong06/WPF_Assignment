using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ILoginService
    {
        public Member Login(string email, string password);

        public void Logout();
    }
}
