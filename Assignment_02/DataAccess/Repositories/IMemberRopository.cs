using BussinessObject.Models;

namespace DataAccess.Repositories
{
    public interface IMemberRopository
    {
        public Member? CheckLogin(string email, string password);
        public List<Member> GetMembers();
        public Member GetMemberByID(int id);
        public void AddMember(Member member);
        public void UpdateMember(Member member);
        public Member CheckEmail(string email);
        public void DeleteMember(int id);
    }
}
