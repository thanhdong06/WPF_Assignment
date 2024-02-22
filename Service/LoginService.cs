using BO;
using Microsoft.Data.SqlClient;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Service
{
    public class LoginService : ILoginService
    {
        private readonly IAccountRepo _accountRepo;
        private Member _trackLogin;

        public LoginService(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public Member Login(string email, string password)
        {
            Member member = _accountRepo.GetMemberAccountByEmail(email);
            if (member != null && member.Password == password)
            {
                _trackLogin = member;
                return member;
            }
            return null;
        }

        public void Logout()
        {
            _trackLogin = null;
        }
    }
}
