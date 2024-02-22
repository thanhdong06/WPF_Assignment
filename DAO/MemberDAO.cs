using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private readonly WPFManagementContext dbContext = null;

        public MemberDAO()
        {
            if( dbContext == null)
            {
                dbContext = new WPFManagementContext();
            }
        }
        public static MemberDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MemberDAO();
                }
                return instance;
            }
        }

        public Member GetMemberAccount(int memberID)
        {
            return dbContext.Members.FirstOrDefault(m => m.Id.Equals(memberID));
        }
        public Member GetMemberAccountByEmail(string email)
        {
            return dbContext.Members.FirstOrDefault(m => m.Email.Equals(email));
        }
        public List<Member> GetMemberAccounts()
        {
            return dbContext.Members.ToList();
        }

        public void AddMemberAccount(Member account)
        {
            Member staff = GetMemberAccount(account.Id);
            if (staff == null)
            {
                dbContext.Add(account);
                dbContext.SaveChanges();
            }

        }

        public void DeleteMemberAccount(Member member)
        {
                dbContext.Remove(member);
                dbContext.SaveChanges();          
        }
    }
}
