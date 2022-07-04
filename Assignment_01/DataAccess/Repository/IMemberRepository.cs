using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.BusinessObject;

namespace Assignment1.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberObject> GetMembers();
        MemberObject GetMemberByID(int ID);
        MemberObject GetAdminAccount();
        void InsertMember(MemberObject mem);
        void UpdateMember(MemberObject mem);
        void DeleteMember(int ID);
        MemberObject CheckLogin(string email, string pass);
    }
}
