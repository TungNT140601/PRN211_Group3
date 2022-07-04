using Assignment1.BusinessObject;
using Assignment1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public MemberObject GetMemberByID(int ID) => MemberDAO.Instance.GetMemberByID(ID);
        public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.GetMemberList();
        public void InsertMember(MemberObject mem) => MemberDAO.Instance.AddNew(mem);
        public void DeleteMember(int ID) => MemberDAO.Instance.Remove(ID);
        public void UpdateMember(MemberObject mem) => MemberDAO.Instance.Update(mem);
        public MemberObject CheckLogin(string email, string pass) => MemberDAO.Instance.CheckLogin(email, pass);
        public MemberObject GetAdminAccount() => MemberDAO.Instance.GetAdminAccount();
    }
}
