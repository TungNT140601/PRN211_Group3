using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using BusinessObject;

namespace Demo
{
    public class Program : BaseDAL
    {
        public static MemberObject CheckLogin(string email, string pass)
        {
            MemberObject mem = null;
            IDataReader reader = null;
            string SQL = "SELECT [MemberId],[Email],[Companyname],[City],[Country],[Password] FROM [FStore].[dbo].[Member] WHERE [Email] like @Email AND  [Password] like @Password";
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@Email", 50, email, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Password", 50, pass, DbType.String));
                reader = dataProvider.GetDataReader(SQL, CommandType.Text, out connection, parameters.ToArray());
                if (reader.Read())
                {
                    mem = new MemberObject
                    {
                        MemberId = reader.GetInt32(0),
                        Email = reader.GetString(1),
                        CompanyName = reader.GetString(2),
                        City = reader.GetString(3),
                        Country = reader.GetString(4),
                        Password = reader.GetString(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                CloseConnection();
            }
            return mem;
        }
        public static void Main()
        {
            BaseDAL baseDAL = new BaseDAL();
            Console.WriteLine(baseDAL.GetConnectionString());
            MemberObject mem = CheckLogin("member1@gmail.com","123");
            if(mem != null)
            {
                Console.WriteLine(mem.Email.ToString());
            }
            else
            {
                Console.WriteLine("Error input");
            }
        }
    }
}