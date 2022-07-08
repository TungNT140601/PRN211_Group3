using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MemberDAO : FStoreContext
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
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
        public MemberDAO() { }
        public List<Member> GetMembers()
        {
            List<Member> members;
            try
            {
                FStoreContext fStoreContext = new FStoreContext();
                members = fStoreContext.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }
        public Member? GetMemberByID(int ID)
        {
            Member? member;
            try
            {
                FStoreContext fStoreContext = new FStoreContext();
                member = fStoreContext.Members.Where(p => p.MemberId == ID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public Member? CheckLogin(string email, string password)
        {
            Member? member;
            try
            {
                FStoreContext fStoreContext = new FStoreContext();
                member = fStoreContext.Members.Where(p => p.Email == email && p.Password == password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (member == null)
            {
                throw new Exception("Wrong email or password");
            }
            return member;
        }
        public void AddMember(Member member)
        {
            try
            {
                FStoreContext fStoreContext = new FStoreContext();
                fStoreContext.Members.Add(member);
                fStoreContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
