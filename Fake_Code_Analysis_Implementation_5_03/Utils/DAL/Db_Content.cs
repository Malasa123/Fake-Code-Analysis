using Fake_Code_Analysis_Implementation_5_03.Models;
using Fake_Code_Analysis_Implementation_5_03.Utils.PropsHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Fake_Code_Analysis_Implementation_5_03.Utils.DAL
{
    public class Db_Content
    {

        public List<CodeFile> GetAllScans()
        {
            List<CodeFile> CodeFiles = new List<CodeFile>();
            string queryString =
            "SELECT * from CodeScans";
            using (SqlConnection connection =
            new SqlConnection(Connections.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var codefile = new CodeFile
                        {
                            Id = reader.GetInt32(0),
                            RawCode = reader.GetString(1),
                            ProgramLanguage = Enum.IsDefined(typeof(ProgramLanguage), reader.GetInt32(2))
                            ? (ProgramLanguage)reader.GetInt32(2) : 0,
                            UserId = reader.GetInt32(3),
                        };
                        CodeFiles.Add(codefile);
                    }
                    reader.Close();
                    return CodeFiles;

                }
                catch
                {
                    CodeFiles = null;
                }
            }
            return CodeFiles;
        }
        public bool InsertScan(CodeFile CodeFile)
        {
            int rowsAffected = 0;
            using (SqlConnection connection =
            new SqlConnection(Connections.GetConnectionString()))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO CodeScans (UserId,RawCode,ProgramLanguage)");
                sb.Append("VALUES ("+CodeFile.UserId+", "+CodeFile.RawCode+", "+CodeFile.ProgramLanguage+");");
                String sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return (rowsAffected > 0) ?  true : false;
        }
        public UserExtention GetUser(int id)
        {
            string queryString =
            @"SELECT Users.Id,Roles.IsAllowed,Roles.Role,Users.UserName
            FROM Users
            INNER JOIN Roles ON Users.RoleId = Roles.Id 
            Where Users.Id = @Id";
            using (SqlConnection connection =
            new SqlConnection(Connections.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();
                    UserExtention user;
                    SqlDataReader reader = command.ExecuteReader();
                    string userId = string.Empty;
                    while (reader.Read())  {
                         user =  new UserExtention
                        {
                            Id = reader.GetInt32(0),
                            IsAllowed = reader.GetBoolean(1),
                            UserName = reader.GetString(3),
                            RoleDescription = reader.GetString(2),
                        };
                        reader.Close();
                        return user;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    return null;
                }
                return null;
            }
        }

    }
}
