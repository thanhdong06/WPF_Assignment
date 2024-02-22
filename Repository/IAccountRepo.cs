using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepo
    {
        public Member GetMemberAccount(int accountId);
        public List<Member> GetMemberAccounts();
        public void AddMemberAccounts(Member account);

        public void DeleteMemberAccount(Member member);

        public Member GetMemberAccountByEmail(string email);
        
    }
}
