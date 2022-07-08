

using BussinessObject.Models;

namespace DataAccess.Repositories
{
    public class MemberRopository : IMemberRopository
    {
        public Member? CheckLogin(string email, string password) => MemberDAO.Instance.CheckLogin(email, password);
    }
}
