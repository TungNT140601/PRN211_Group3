using BussinessObject.Models;

namespace DataAccess.Repositories
{
    public interface IMemberRopository
    {
        public Member? CheckLogin(string email, string password);
    }
}
