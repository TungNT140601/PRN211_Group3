using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.BusinessObject;

namespace Assignment1.DataAccess
{
    public class MemberDAO
    {
        private static List<MemberObject> MemberList = new List<MemberObject>()
        {
            new MemberObject
            {
                ID = 1,
                Name = "Tu",
                City = "Ho Chi Minh city",
                Country = "Vietnam",
                Email = "tu@email.com",
                Password = "12345"
            },
            new MemberObject
            {
                ID = 2,
                Name = "Tung",
                City = "Ho Chi Minh city",
                Country = "Vietnam",
                Email = "tung@email.com",
                Password = "12345"
            },
            new MemberObject
            {
                ID = 3,
                Name = "Vu",
                City = "Ho Chi Minh city",
                Country = "Vietnam",
                Email = "vu@email.com",
                Password = "12345"
            },
            new MemberObject
            {
                ID = 4,
                Name = "Truong",
                City = "Ho Chi Minh city",
                Country = "Vietnam",
                Email = "truong@email.com",
                Password = "12345"
            },
            new MemberObject
            {
                ID = 5,
                Name = "Tuong",
                City = "Ho Chi Minh city",
                Country = "Vietnam",
                Email = "tuong@email.com",
                Password = "12345"
            }
        };
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public List<MemberObject> GetMemberList => MemberList;
        public MemberObject? GetMemberByID(int ID)
        {
            MemberObject? mem = MemberList.SingleOrDefault(member => member.ID == ID);
            return mem;
        }
        public MemberObject? CheckLogin(string email, string password)
        {
            MemberObject? mem = MemberList.SingleOrDefault(member => (member.Email == email && member.Password == password));
            return mem;
        }
        public void Add(MemberObject mem)
        {
            MemberObject member = GetMemberByID(mem.ID);
            if (member == null)
            {
                MemberList.Add(mem);
            }
            else
            {
                throw new Exception("Member is already exists.");
            }
        }
        public void Update(MemberObject mem)
        {
            MemberObject member = GetMemberByID(mem.ID);
            if (member != null)
            {
                var index = MemberList.IndexOf(member);
                MemberList[index] = mem;
            }
            else
            {
                throw new Exception("Member dose not exists.");
            }
        }
        public void Remove(int ID)
        {
            MemberObject mem = GetMemberByID(ID);
            if (mem != null)
            {
                MemberList.Remove(mem);
            }
            else
            {
                throw new Exception("Member dose not exists.");
            }
        }
    }
}
