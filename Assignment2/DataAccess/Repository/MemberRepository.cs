using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public MemberObject CheckLogin(string email, string password) => MemberDAO.Instance.CheckLogin(email, password);

        public IEnumerable<MemberObject> GetMemberList() => MemberDAO.Instance.GetMemberList();
        public MemberObject GetMemberByID(int memID) => MemberDAO.Instance.GetMemberByID(memID);
        public void InsertMem(MemberObject mem) => MemberDAO.Instance.AddNew(mem);
        public void DeleteMem(int memID) => MemberDAO.Instance.Remove(memID);
        public void UpdateMem(MemberObject mem) => MemberDAO.Instance.Update(mem);

    }
}
