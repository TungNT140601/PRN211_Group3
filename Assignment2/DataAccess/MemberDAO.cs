using System.Data;
using Microsoft.Data.SqlClient;
using BusinessObject;

namespace DataAccess
{
    public class MemberDAO : BaseDAL
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
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

        public MemberObject CheckLogin(string email, string pass)
        {
            MemberObject mem = null;
            IDataReader reader = null;
            string SQL = "SELECT [MemberId],[Email],[Companyname],[City],[Country],[Password] FROM [FStore].[dbo].[Member] WHERE [Email] like @Email AND [Password] like @Password";
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
        public IEnumerable<MemberObject> GetMemberList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT [MemberId],[Email],[Companyname],[City],[Country],[Password] FROM [FStore].[dbo].[Member]";
            var members = new List<MemberObject>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    members.Add(new MemberObject
                    {
                        MemberId = dataReader.GetInt32(0),
                        Email = dataReader.GetString(1),
                        CompanyName = dataReader.GetString(2),
                        City = dataReader.GetString(3),
                        Country = dataReader.GetString(4),
                        Password = dataReader.GetString(5)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return members;
        }

        public MemberObject GetMemberByID(int memID)
        {
            MemberObject? mem = null;
            IDataReader? dataReader = null;
            string SQLSelect = "SELECT MemberId, Email, Companyname, City, Country, Password FROM Member WHERE MemberId = @MemberId";
            try
            {
                var param = dataProvider.CreateParameter("@MemberId", 4, memID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    mem = new MemberObject
                    {
                        MemberId = dataReader.GetInt32(0),
                        Email = dataReader.GetString(1),
                        CompanyName = dataReader.GetString(2),
                        City = dataReader.GetString(3),
                        Country = dataReader.GetString(4),
                        Password = dataReader.GetString(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return mem;
        }

        public void AddNew(MemberObject mem)
        {
            try
            {
                MemberObject member = GetMemberByID(mem.MemberId);
                if (member == null)
                {
                    string SQLInsert = "INSERT Member values(@MemberId, @Email, @Companyname, @City, @Country, @Password)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MemberId", 4, mem.MemberId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@Email", 50, mem.Email, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Companyname", 50, mem.CompanyName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@City", 50, mem.City, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Country", 50, mem.Country, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Password", 50, mem.Password, DbType.String));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("This Member is already exits.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(MemberObject mem)
        {
            try
            {
                MemberObject member = GetMemberByID(mem.MemberId);
                if (member != null)
                {
                    string SQLUpdate = "UPDATE Member set Email = @Email,Companyname = @Companyname,City = @City, Country = @Country, Password = @Password WHERE MemberId = @MemberId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MemberId", 4, mem.MemberId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@Email", 50, mem.Email, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Companyname", 50, mem.CompanyName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@City", 50, mem.City, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Country", 50, mem.Country, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Password", 50, mem.Password, DbType.String));
                    dataProvider.Insert(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("Member does not already exits.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Remove(int memID)
        {
            try
            {
                MemberObject member = GetMemberByID(memID);
                if (member != null)
                {
                    string SQLDelete = "DELETE Member WHERE MemberId = @MemberId";
                    var param = dataProvider.CreateParameter("@MemberId", 4, memID, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("Member does not already exits.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
