using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class StaffRepo
    {
        private string connectionstring = "";
        public List<Staff> Staffs;
        public StaffRepo(string c)
        {
            this.connectionstring = c;
            Staffs = new List<Staff>();
        }

        public List<Staff> GetAllStaff()
        {
            Staffs.Clear();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string query = "SELECT * FROM Staff";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Staff t = new Staff
                            {
                                StaffID = Convert.ToInt32(reader["StaffID"]),
                                Name = reader["S_Name"] is DBNull ? " " : (string)reader["S_Name"],
                                Qualification = reader["S_Qualification"] is DBNull ? " " : (string)reader["S_Qualification"],
                                Status = reader["S_Status"] is DBNull ? " " : (string)reader["S_Status"],
                                Gender = reader["S_Gender"] is DBNull ? " " : (string)reader["S_Gender"],
                                DOB = DateTime.TryParse(reader["S_DOB"].ToString(), out var dob) ? (DateTime?)dob : null,
                                Disablity = reader["S_Disability"] is DBNull ? " " : (string)reader["S_Disability"],
                                Age = Convert.ToInt32(reader["S_Age"]),
                                Role = (reader["S_Role"]).ToString(),
                                Salary = Convert.ToInt32(reader["S_Salary"]),
                                Joining_Date = DateTime.TryParse(reader["S_JoiningDate"].ToString(), out var jd) ? (DateTime?)jd : null,
                                Photo = reader["S_Photo"] is DBNull ? null : (byte[])reader["S_Photo"],
                                CNIC = Convert.ToInt64(reader["S_CNIC"]),
                                Address = reader["S_Address"] is DBNull ? " " : (string)reader["S_Address"],
                                Phone_Number = Convert.ToInt64(reader["S_PhoneNumber"]),
                                DepartureDate = DateTime.TryParse(reader["S_DepartureDate"].ToString(), out var dd) ? (DateTime?)dd : null
                            };

                            Staffs.Add(t);
                        }
                    }
                }
            }
            for (int i = 0; i < Staffs.Count; i++)
            {
                for (int j = i; j < Staffs.Count; j++)
                {
                    if (Staffs[i].StaffID > Staffs[j].StaffID)
                    {
                        Staff temp = Staffs[i];
                        Staffs[i] = Staffs[j];
                        Staffs[j] = temp;
                    }
                }
            }

            return Staffs;
        }

        public void AddStaff(List<Staff> staff)
        {

            if (staff != null)
            {
                //Staff.AddRange(staff);

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {

                    conn.Open();
                    foreach (Staff t in staff)
                    {

                        try
                        {
                            string query = "INSERT INTO Staff(" +
                                    "StaffID, S_Name, S_Qualification, S_Status,S_Gender, S_DOB, " +
                                    "S_Age, S_Disability, S_Role, S_Salary," +
                                    "S_JoiningDate, S_Photo, S_CNIC, S_Address, S_PhoneNumber," +
                                    "S_DepartureDate)"+                                  
                                    " VALUES (" +
                                    "@id, @name,@qua, @status, @gender, @dob, @age, @dis, @role, " +
                                    "@salary, @jd, @img, @cnic,@add, @pn," +
                                    "@dd);";
                            


                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {

                                cmd.Parameters.AddWithValue("@id", t.StaffID);
                                cmd.Parameters.AddWithValue("@name", t.Name);
                                cmd.Parameters.AddWithValue("@gender", t.Gender);
                                cmd.Parameters.AddWithValue("@qua", t.Qualification);
                                cmd.Parameters.AddWithValue("@status", t.Status);
                                cmd.Parameters.AddWithValue("@dob", t.DOB);
                                cmd.Parameters.AddWithValue("@age", t.Age);
                                cmd.Parameters.AddWithValue("@dis", t.Disablity ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@role", t.Role);
                                cmd.Parameters.AddWithValue("@salary", t.Salary);
                                cmd.Parameters.AddWithValue("@jd", t.Joining_Date);
                                cmd.Parameters.AddWithValue("@img", t.Photo);
                                cmd.Parameters.AddWithValue("@cnic", t.CNIC);
                                cmd.Parameters.AddWithValue("@dd", t.DepartureDate.HasValue ? (object)t.DepartureDate : DBNull.Value);
                                cmd.Parameters.AddWithValue("@add", t.Address);
                                cmd.Parameters.AddWithValue("@pn", t.Phone_Number);
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
        public void RemoveStaffs(List<int> ids)
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
                            using (SqlCommand command = new SqlCommand("DELETE Staff WHERE StaffID = @id", connection, transaction))
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
        public void UpdateStaff(int id, Staff t)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Staff SET " +
                            "S_Name = @name,S_Qualification = @qua,S_Status = @status,S_Gender = @gender," +
                            "S_DOB = @dob,S_Age = @age,S_Disability = @dis,S_Role = @role,S_Salary = @salary," +
                            "S_JoiningDate = @jd,S_Photo = @img,S_CNIC = @cnic,S_Address = @add," +
                            "S_PhoneNumber = @pn,S_DepartureDate = @dd WHERE StaffID = @n;", connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@n", id);
                            cmd.Parameters.AddWithValue("@id", t.StaffID);
                            cmd.Parameters.AddWithValue("@name", t.Name);
                            cmd.Parameters.AddWithValue("@gender", t.Gender);
                            cmd.Parameters.AddWithValue("@qua", t.Qualification ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@status", t.Status);
                            cmd.Parameters.AddWithValue("@dob", t.DOB);
                            cmd.Parameters.AddWithValue("@age", t.Age);
                            cmd.Parameters.AddWithValue("@dis", t.Disablity ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@role", t.Role);
                            cmd.Parameters.AddWithValue("@salary", t.Salary);
                            cmd.Parameters.AddWithValue("@jd", t.Joining_Date);
                            cmd.Parameters.AddWithValue("@img", t.Photo);
                            cmd.Parameters.AddWithValue("@cnic", t.CNIC);
                            cmd.Parameters.AddWithValue("@dd", t.DepartureDate.HasValue ? (object)t.DepartureDate : DBNull.Value);
                            cmd.Parameters.AddWithValue("@add", t.Address);
                            cmd.Parameters.AddWithValue("@pn", t.Phone_Number);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show($"Employee with ID: {id} has been updated with Ne ID: {t.StaffID}");
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
