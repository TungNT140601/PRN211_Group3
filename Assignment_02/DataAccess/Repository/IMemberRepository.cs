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
        IEnumerable<MemberObject> GetMembers();
        MemberObject GetMemberByID(int memID);
        void InsertMem(MemberObject mem);
        void UpdateMem(MemberObject mem);
        void DeleteMem(int memID);
        MemberObject CheckLogin(int memID, String pass);
    }
}
