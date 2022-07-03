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
    }
}
