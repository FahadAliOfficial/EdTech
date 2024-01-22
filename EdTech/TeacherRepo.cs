using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.ComponentModel.Design.ObjectSelectorEditor;
namespace EdTech
{
    public class TeacherRepo : iTeacherRepo
    {
        //Teacher
        private string connectionstring = "";
        public List<Teacher> Teachers;

        public TeacherRepo(string cs)
        {
            Teachers = new List<Teacher>();
            connectionstring = cs;

        }
        public List<int> getClassNumbers()
        {
            List<int> classNum = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string query = "SELECT C_Grade FROM S_Class";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int entry = Convert.ToInt32(reader["C_Grade"]);
                            classNum.Add(entry);
                        }
                    }
                }
            }
            for (int i = 0; i < classNum.Count; i++)
            {
                for (int j = i; j < classNum.Count; j++)
                {
                    if (classNum[i] > classNum[j])
                    {
                        int temp = classNum[i];
                        classNum[i] = classNum[j];
                        classNum[j] = temp;
                    }
                }
            }
            return classNum;
        }
        public List<Teacher> GetAllTeachers()
        {
            Teachers.Clear();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string query = "SELECT t.*, S.TotalSalary FROM Teacher t LEFT JOIN Salary S ON t.TeacherID = S.TeacherID";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Teacher t = new Teacher
                            {
                                TeacherID = Convert.ToInt32(reader["TeacherID"]),
                                Name = reader["T_Name"] is DBNull ? " " : (string)reader["T_Name"],
                                Gender = reader["T_Gender"] is DBNull ? " " : (string)reader["T_Gender"],
                                DOB = DateTime.TryParse(reader["T_DOB"].ToString(), out var dob) ? (DateTime?)dob : null,
                                Age = Convert.ToInt32(reader["T_Age"]), 
                                Disablity = reader["T_Disability"] is DBNull ? " " : (string)reader["T_Disability"],
                                Role = (reader["T_Role"]).ToString(),
                                Salary = reader["TotalSalary"] is DBNull ? 0 : Convert.ToInt32(reader["TotalSalary"]),
                                Joining_Date = DateTime.TryParse(reader["T_JoiningDate"].ToString(), out var jd) ? (DateTime?)jd : null,
                                Qualification = (reader["T_Qualification"]).ToString(),
                                InchargeShip = Convert.ToInt32(reader["T_InchargeShip"]),
                                CNIC = Convert.ToInt64(reader["T_CNIC"]),
                                Phone_Number = Convert.ToInt64(reader["T_PhoneNumber"]),
                                DepartureDate = DateTime.TryParse(reader["T_DepartureDate"].ToString(), out var dd) ? (DateTime?)dd : null,
                                Address = reader["T_Address"] is DBNull ? " " : (string)reader["T_Address"],
                                Photo = reader["T_Photo"] is DBNull ? null : (byte[])reader["T_Photo"]
                            };

                            Teachers.Add(t);
                        }
                    }
                }
            }
            for (int i = 0; i < Teachers.Count; i++)
            {
                for (int j = i; j < Teachers.Count; j++)
                {
                    if (Teachers[i].TeacherID > Teachers[j].TeacherID)
                    {
                        Teacher temp = Teachers[i];
                        Teachers[i] = Teachers[j];
                        Teachers[j] = temp;
                    }
                }
            }

            return Teachers;
        }

        public void AddTeacher(List<Teacher> teacher)
        {

            if (teacher != null)
            {
                Teachers.AddRange(teacher);

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {

                    conn.Open();
                    foreach (Teacher t in teacher)
                    {

                        try
                        {
                            string query = "INSERT INTO Teacher (" +
                                "TeacherID, T_Name, T_Gender, T_DOB, " +
                                "T_Age, T_Disability, T_Role," +
                                "T_JoiningDate, T_Photo, T_Qualification, T_InchargeShip," +
                                "T_CNIC, T_PhoneNumber, T_DepartureDate, T_Address)" +
                                " VALUES (" +
                                "@id, @name, @gender, @dob, @age,@dis,@role, " +
                                 "@jd, @img, @qua, @incharge, @cnic, @pn, " +
                                 "@dd, @add);";


                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {

                                cmd.Parameters.AddWithValue("@id", t.TeacherID);
                                cmd.Parameters.AddWithValue("@name", t.Name);
                                cmd.Parameters.AddWithValue("@gender", t.Gender);
                                cmd.Parameters.AddWithValue("@dob", t.DOB);
                                cmd.Parameters.AddWithValue("@age", t.Age);
                                cmd.Parameters.AddWithValue("@dis", t.Disablity ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@role", t.Role);
                                cmd.Parameters.AddWithValue("@jd", t.Joining_Date);
                                cmd.Parameters.AddWithValue("@img", t.Photo);
                                cmd.Parameters.AddWithValue("@qua", t.Qualification);
                                cmd.Parameters.AddWithValue("@incharge", t.InchargeShip);
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

        public void AddTeacher(Teacher tec)
        {


        }

        public void RemoveTeacher(List<int> ids)
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
                            using (SqlCommand command = new SqlCommand("DELETE Teacher WHERE TeacherID = @id", connection, transaction))
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





        public void UpdateTeacher(int id, Teacher t)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Teacher SET" +
                                "TeacherID = @id, T_Name = @name, T_Gender= @gender, T_DOB=@dob, " +
                                "T_Age = @age, T_Disability = @dis, T_Role=@role," +
                                "T_JoiningDate = @jd, T_Photo = @img, T_Qualification = @qua, T_InchargeShip = @incharge," +
                                "T_CNIC = @cnic, T_PhoneNumber = @pn, T_DepartureDate = @dd, T_Address = @add",connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", t.TeacherID);
                            cmd.Parameters.AddWithValue("@name", t.Name);
                            cmd.Parameters.AddWithValue("@gender", t.Gender);
                            cmd.Parameters.AddWithValue("@dob", t.DOB);
                            cmd.Parameters.AddWithValue("@age", t.Age);
                            cmd.Parameters.AddWithValue("@dis", t.Disablity ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@role", t.Role);
                            cmd.Parameters.AddWithValue("@jd", t.Joining_Date);
                            cmd.Parameters.AddWithValue("@img", t.Photo);
                            cmd.Parameters.AddWithValue("@qua", t.Qualification);
                            cmd.Parameters.AddWithValue("@incharge", t.InchargeShip);
                            cmd.Parameters.AddWithValue("@cnic", t.CNIC);
                            cmd.Parameters.AddWithValue("@dd", t.DepartureDate.HasValue ? (object)t.DepartureDate : DBNull.Value);
                            cmd.Parameters.AddWithValue("@add", t.Address);
                            cmd.Parameters.AddWithValue("@pn", t.Phone_Number);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show($"Teacher with ID: {id} has been updated with Ne ID: {t.TeacherID}");
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
