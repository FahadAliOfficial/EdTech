using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using System.Xml;

namespace EdTech
{
    public class ClassRepo:iClassRepo
    {
        public string connectionstring = "";
        public List<S_Class> Classes;
        public ClassRepo(string connectionstring)
        {
            this.connectionstring = connectionstring;
            Classes = new List<S_Class>();
        }
        public List<S_Class> GetAllClasses()
        {
            Classes.Clear();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string query = "SELECT * FROM S_Class";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            S_Class t = new S_Class
                            {
                                ClassID = Convert.ToInt32(reader["ClassID"]),
                                Grade = Convert.ToInt32(reader["C_Grade"]),
                                NumStd = Convert.ToInt32(reader["C_NumStd"]),
                                NumChairs =  Convert.ToInt32(reader["C_NumChairs"]),
                                NumTables = Convert.ToInt32(reader["C_NumTables"]),
                                RoomNo = Convert.ToInt32(reader["C_RoomNo"]),
                                stdCap= Convert.ToInt32(reader["C_TotalCapacity"]),
                                Section = reader["C_Section"] is DBNull ? " " : (string)reader["C_Section"],

                            };

                            Classes.Add(t);
                        }
                    }
                }
            }
            for (int i = 0; i < Classes.Count; i++)
            {
                for (int j = i; j < Classes.Count; j++)
                {
                    if (Classes[i].ClassID > Classes[j].ClassID)
                    {
                        S_Class temp = Classes[i];
                        Classes[i] = Classes[j];
                        Classes[j] = temp;
                    }
                }
            }
            
            return Classes;
        }
        public void AddClass(List<S_Class> C)
        {
            if (C != null)
            {


                    using (SqlConnection conn = new SqlConnection(connectionstring))
                    {
                        conn.Open();
                    foreach (S_Class cc in C)
                    {

                        try
                        {
                            string query = "INSERT INTO S_Class (" +
                                "ClassID, C_Grade, C_NumStd, C_NumChairs, " +
                                "C_NumTables, C_RoomNo, C_TotalCapacity, C_Section)" +
                                " VALUES (" +
                                "@id, @name, @std, @chair, @table,@room,@cap, @section);";


                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {

                                cmd.Parameters.AddWithValue("@id", cc.ClassID);
                                cmd.Parameters.AddWithValue("@name", cc.Grade);
                                cmd.Parameters.AddWithValue("@std", cc.NumStd);
                                cmd.Parameters.AddWithValue("@chair", cc.NumChairs);
                                cmd.Parameters.AddWithValue("@table", cc.NumTables);
                                cmd.Parameters.AddWithValue("@room", cc.RoomNo);
                                cmd.Parameters.AddWithValue("@cap", cc.stdCap);
                                cmd.Parameters.AddWithValue("@section", cc.Section);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627 || ex.Number == 2601)
                            {
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Database Error: {ex}");
                        }
                    }
                }
            }
        }
        
        public void RemoveClass(List<int> ids) 
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int rowsAffected = 0;

                        foreach (int id in ids)
                        {
                            using (SqlCommand command = new SqlCommand("DELETE S_Class WHERE TeacherID = @ClassID", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@id", id);
                                rowsAffected += command.ExecuteNonQuery();
                            }
                        }

                        if (rowsAffected == ids.Count)
                        {
                            transaction.Commit();
                            MessageBox.Show("Transaction committed successfully");
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Transaction rolled back: Not all rows affected");
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Transaction rolled back due to exception: " + ex.Message);
                    }
                }
            }
        }
        public void UpdateClass(int id, S_Class cc) 
        {

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE S_Class SET ClassID = @nid, C_Grade = @name, C_NumStd = @std, C_NumChairs = @chair, " +
                            "C_NumTables = @table, C_RoomNo = @room, C_TotalCapacity = @cap, C_Section = @section WHERE ClassID = @eid", connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@eid", id);
                            cmd.Parameters.AddWithValue("@nid", cc.ClassID);
                            cmd.Parameters.AddWithValue("@name", cc.Grade);
                            cmd.Parameters.AddWithValue("@std", cc.NumStd);
                            cmd.Parameters.AddWithValue("@chair", cc.NumChairs);
                            cmd.Parameters.AddWithValue("@table", cc.NumTables);
                            cmd.Parameters.AddWithValue("@room", cc.RoomNo);
                            cmd.Parameters.AddWithValue("@cap", cc.stdCap);
                            cmd.Parameters.AddWithValue("@section", cc.Section);


                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                                Console.WriteLine("Transaction rolled back: No rows affected");
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Transaction rolled back due to exception rasied here: " + ex.Message);
                    }
                }
            }
        }
    }
}
