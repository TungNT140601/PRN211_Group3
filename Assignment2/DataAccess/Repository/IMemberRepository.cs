using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberObject> GetMemberList();
        public MemberObject CheckLogin(string email, string password);
        public MemberObject GetMemberByID(int memID);
        public void InsertMem(MemberObject mem);
        public void UpdateMem(MemberObject mem);
        public void DeleteMem(int memID);
    }
}
