using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using BusinessObject;
using System;
namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
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
        public MemberDAO()
        {
            var connectionString = GetConnectionString();
            m = new MemberDAO(connectionString);
        }
        public MemberDAO m { get; set; } = null;
        public SqlConnection connection = null;
        public string GetConnectionString()
        {
            string connectionString;
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsetting.json", true, true)
                                        .Build();
            connectionString = config["ConnectionString:FStoreDB"];
            return connectionString;
        }
        public void CloseConnection() => m.CloseConnection(connection);

        private string ConnectionString { get; set; }
        public MemberDAO(string connectionString) => ConnectionString = connectionString;
        public void CloseConnection(SqlConnection connection) => connection.Close();
        public SqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                Value = value,
            };
        }
        public IDataReader GetDataReader(string commandText, CommandType commandType, out SqlConnection connection, params SqlParameter[] parameters)
        {
            IDataReader reader = null;
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return reader;
        }
        public void Delete(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insert(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<MemberObject> GetMemberList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT MemberId, Email, Companyname, City, Country, Password FROM Member";
            var mem = new List<MemberObject>();
            try
            {
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    mem.Add(new MemberObject
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
            return mem;
        }

        public MemberObject GetMemberByID(int memID)
        {
            MemberObject mem = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT MemberId, Email, Companyname, City, Country, Password FROM Member WHERE MemberId = @MemberId";
            try
            {
                var param = CreateParameter("@MemberId", 4, memID, DbType.Int32);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, param);
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

        public MemberObject CheckLogin(String email, String password)
        {
            MemberObject mem = null;
            IDataReader dataReader = null;
            try
            {
                
                string SQLSelect = "SELECT MemberId, Email, Companyname, City, Country, Password FROM Member WHERE Email = @Email AND Password = @Password";
                var mail = CreateParameter("@Email", 4, email, DbType.String);
                var pass = CreateParameter("@Password", 4, password, DbType.String);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, mail); ;
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, pass);
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
            }catch (Exception ex)
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
                if (member.MemberId == null)
                {
                    string SQLInsert = "INSERT Member values(@MemberId, @Email, @Companyname, @City, @Country, @Password)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(CreateParameter("@MemberId", 4, mem.MemberId, DbType.Int32));
                    parameters.Add(CreateParameter("@Email", 4, mem.Email, DbType.String));
                    parameters.Add(CreateParameter("@Companyname", 50, mem.CompanyName, DbType.String));
                    parameters.Add(CreateParameter("@City", 50, mem.City, DbType.String));
                    parameters.Add(CreateParameter("@Country", 50, mem.Country, DbType.String));
                    parameters.Add(CreateParameter("@Password", 4, mem.Password, DbType.String));
                    Insert(SQLInsert, CommandType.Text, parameters.ToArray());
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
                    parameters.Add(CreateParameter("@MemberId", 4, mem.MemberId, DbType.Int32));
                    parameters.Add(CreateParameter("@Email", 4, mem.Email, DbType.String));
                    parameters.Add(CreateParameter("@Companyname", 50, mem.CompanyName, DbType.String));
                    parameters.Add(CreateParameter("@City", 50, mem.City, DbType.String));
                    parameters.Add(CreateParameter("@Country", 50, mem.Country, DbType.String));
                    parameters.Add(CreateParameter("@Password", 4, mem.Password, DbType.String));
                    Insert(SQLUpdate, CommandType.Text, parameters.ToArray());
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
                    var param = CreateParameter("@MemberId", 4, memID, DbType.Int32);
                    Delete(SQLDelete, CommandType.Text, param);
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