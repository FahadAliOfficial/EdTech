using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace EdTech
{
    public class UserRepo
    {
        private readonly string connectionstring = "Data Source=DESKTOP-C3NF4Q2\\SQLEXPRESS;Initial Catalog=EdTech;Integrated Security=True;";
        public User GetUser(string un,string p)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

               
                    string query = "SELECT * FROM S_User WHERE T_UserName = @username AND T_Password = @pas";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", un);
                    command.Parameters.AddWithValue("@pas", p);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = (int)reader["T_UserID"],
                                Username = reader["T_UserName"].ToString(),
                                Password = reader["T_Password"].ToString(),

                            };
                        }
                        else
                        {
                            MessageBox.Show("No User Found..");
                        }
                    }
                }
                
            }
                    
            

            return null;
        }
    }
}
