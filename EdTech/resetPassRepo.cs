using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class resetPassRepo
    {
        private readonly string connectionstring = "Data Source=DESKTOP-C3NF4Q2\\SQLEXPRESS;Initial Catalog=EdTech;Integrated Security=True;";
        public int findUser(string u, string p)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {

                conn.Open();

                string query = "SELECT T_UserID FROM S_User WHERE T_UserName = @username AND T_Phrase = @phrase";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", u);
                    command.Parameters.AddWithValue("@phrase", p);

                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                    
                }
            }

        }
        public bool updatepass(int i, string p)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {

                conn.Open();
                using(SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "UPDATE S_User SET T_Password = @pass WHERE T_UserID = @id";
                        using (SqlCommand command = new SqlCommand(query, conn,transaction))
                        {
                            command.Parameters.AddWithValue("@pass", p);
                            command.Parameters.AddWithValue("@id", i);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Exception: " + ex.Message);
                        transaction.Rollback();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                        transaction.Rollback();
                        return false;
                    }
                }
                
            }
        }
    }
}
