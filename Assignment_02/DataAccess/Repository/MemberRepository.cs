using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public MemberObject GetMemberByID(int memID) => MemberDAO.Instance.GetMemberByID(memID);
        public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.GetMemberList();
        public void InsertMem(MemberObject mem) => MemberDAO.Instance.AddNew(mem);
        public void DeleteMem(int memID) => MemberDAO.Instance.Remove(memID);
        public void UpdateMem(MemberObject mem) => MemberDAO.Instance.Update(mem);
        public MemberObject CheckLogin(string email, string pass) => MemberDAO.Instance.CheckLogin(email, pass);
    }
}
