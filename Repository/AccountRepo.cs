using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepo : IAccountRepo
    {
        public void AddMemberAccounts(Member account) => MemberDAO.Instance.AddMemberAccount(account);

        public Member GetMemberAccount(int accountId) => MemberDAO.Instance.GetMemberAccount(accountId);

        public Member GetMemberAccountByEmail(string email) => MemberDAO.Instance.GetMemberAccountByEmail(email);

        public List<Member> GetMemberAccounts() => MemberDAO.Instance.GetMemberAccounts();

        public void DeleteMemberAccount(Member member) => MemberDAO.Instance.DeleteMemberAccount(member);
    }
}
