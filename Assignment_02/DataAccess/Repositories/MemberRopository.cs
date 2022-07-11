

using BussinessObject.Models;

namespace DataAccess.Repositories
{
    public class MemberRopository : IMemberRopository
    {
        public Member? CheckLogin(string email, string password) => MemberDAO.Instance.CheckLogin(email, password);
        public List<Member> GetMembers() => MemberDAO.Instance.GetMembers();
        public Member GetMemberByID(int id) => MemberDAO.Instance.GetMemberByID(id);
        public void AddMember(Member member) => MemberDAO.Instance.AddMember(member);
        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
        public Member CheckEmail(string email) => MemberDAO.Instance.CheckEmail(email);
        public void DeleteMember(int id) => MemberDAO.Instance.DeleteMember(id);
    }
}
