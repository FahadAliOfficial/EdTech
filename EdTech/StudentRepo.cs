using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EdTech
{
    public class StudentRepo:iStudentRepo
    {
        public List<Student> Students;
        private string connectionstring;

        public StudentRepo(string cs) 
        {
            Students = new List<Student>();
       
            connectionstring = cs;
        }
        //Methods for Students
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
        public List<Student> GetAllStudents()
        {
            Students.Clear();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string query = "SELECT * FROM Student";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student t = new Student
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                Name = reader["Std_Name"] is DBNull ? " " : (string)reader["Std_Name"],
                                Gender = reader["Std_Gender"] is DBNull ? " " : (string)reader["Std_Gender"],
                                DOB = DateTime.TryParse(reader["Std_DOB"].ToString(), out var dob) ? dob : DateTime.MinValue,
                                Disablity = reader["Std_Disability"] is DBNull ? " " : (string)reader["Std_Disability"],
                                Age = Convert.ToInt32(reader["Std_Age"]),
                                Std_Session = Convert.ToInt32(reader["Std_Session"]),
                                Std_BForm = Convert.ToInt64(reader["Std_BForm"]),
                                Std_FName = reader["Std_FName"] is DBNull ? " " : (string)reader["Std_FName"],
                                Std_FPhone = Convert.ToInt64(reader["Std_FPhone"]),
                                Std_FCNIC = Convert.ToInt64(reader["Std_FCNIC"]),
                                Std_MName = reader["Std_MName"] is DBNull ? " " : (string)reader["Std_MName"],
                                Std_MPhone = Convert.ToInt64(reader["Std_MPhone"]),
                                Std_MCNIC = Convert.ToInt64(reader["Std_MCNIC"]),
                                Std_Address = reader["Std_Address"] is DBNull ? " " : (string)reader["Std_Address"],
                                Std_Class = Convert.ToInt32(reader["Std_Class"]),
                                Std_Section = reader["Std_Section"] is DBNull ? " " : (string)reader["Std_Section"],
                                Std_EnrollmentDate = DateTime.TryParse(reader["Std_EnrollementDate"].ToString(), out var en) ? en : DateTime.MinValue,
                                Std_Photo = reader["Std_Photo"] is DBNull ? null : (byte[])reader["Std_Photo"]
                            };

                            Students.Add(t);
                        }
                    }
                }
            }
            for(int i = 0; i< Students.Count; i++)
            {
                for(int j = i; j< Students.Count; j++)
                {
                    if (Students[i].StudentID > Students[j].StudentID)
                    {
                        Student temp = Students[i];
                        Students[i] = Students[j];
                        Students[j] = temp;
                    }
                }
            }
            return Students;
        }
        public void AddStudent(List<Student> students)
        {
            if (students != null)
            {

                foreach (Student std in students)
                {

                    using (SqlConnection conn = new SqlConnection(connectionstring))
                    {

                        conn.Open();
                        try
                        {
                            string query = "INSERT INTO Student (" +
                                "StudentID, Std_Session, Std_Name, Std_Gender, " +
                                "Std_DOB, Std_Age, Std_Disability, Std_BForm," +
                                "Std_FName, Std_FPhone, Std_FCNIC, Std_MName," +
                                "Std_MPhone, Std_MCNIC, Std_Address, Std_Class," +
                                "Std_Section, Std_EnrollementDate, Std_Photo " +
                                ")" +
                                " VALUES (" +
                                "@id, @session, @name, @gender, @dob,@age,@disability, " +
                                 "@bform, @fname, @fpn, @fcnic, @mname, @mpn, @mcnic, " +
                                 "@address, @class, @section, @enrollement_date, @img);";


                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {

                                cmd.Parameters.AddWithValue("@id", std.StudentID);
                                cmd.Parameters.AddWithValue("@session", std.Std_Session);
                                cmd.Parameters.AddWithValue("@name", std.Name);
                                cmd.Parameters.AddWithValue("@gender", std.Gender);
                                cmd.Parameters.AddWithValue("@dob", std.DOB);
                                cmd.Parameters.AddWithValue("@age", std.Age);
                                cmd.Parameters.AddWithValue("@disability", std.Disablity);
                                cmd.Parameters.AddWithValue("@bform", std.Std_BForm);
                                cmd.Parameters.AddWithValue("@fname", std.Std_FName);
                                cmd.Parameters.AddWithValue("@fpn", std.Std_FPhone);
                                cmd.Parameters.AddWithValue("@fcnic", std.Std_FCNIC);
                                cmd.Parameters.AddWithValue("@mname", std.Std_MName);
                                cmd.Parameters.AddWithValue("@mpn", std.Std_MPhone);
                                cmd.Parameters.AddWithValue("@mcnic", std.Std_MCNIC);
                                cmd.Parameters.AddWithValue("@address", std.Std_Address);
                                cmd.Parameters.AddWithValue("@class", std.Std_Class);
                                cmd.Parameters.AddWithValue("@section", std.Std_Section);
                                cmd.Parameters.AddWithValue("@enrollement_date", std.Std_EnrollmentDate);
                                cmd.Parameters.AddWithValue("@img", std.Std_Photo);
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

        public void AddStudent(Student std)
        {


            using (SqlConnection conn = new SqlConnection(connectionstring))
            {

                conn.Open();
                try
                {


                    string query = "INSERT INTO Student (" +
                        "StudentID, Std_Session, Std_Name, Std_Gender, " +
                        "Std_DOB, Std_Age, Std_Disability, Std_BForm," +
                        "Std_FName, Std_FPhone, Std_FCNIC, Std_MName," +
                        "Std_MPhone, Std_MCNIC, Std_Address, Std_Class," +
                        "Std_Section, Std_EnrollementDate, Std_Photo " +
                        ")" +
                        " VALUES (" +
                        "@id, @session, @name, @gender, @dob,@age,@disability, " +
                         "@bform, @fname, @fpn, @fcnic, @mname, @mpn, @mcnic, " +
                         "@address, @class, @section, @enrollement_date, @img);";



                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@id", std.StudentID);
                        cmd.Parameters.AddWithValue("@session", std.Std_Session);
                        cmd.Parameters.AddWithValue("@name", std.Name);
                        cmd.Parameters.AddWithValue("@gender", std.Gender);
                        cmd.Parameters.AddWithValue("@dob", std.DOB);
                        cmd.Parameters.AddWithValue("@age", std.Age);
                        cmd.Parameters.AddWithValue("@disability", std.Disablity);
                        cmd.Parameters.AddWithValue("@bform", std.Std_BForm);
                        cmd.Parameters.AddWithValue("@fname", std.Std_FName);
                        cmd.Parameters.AddWithValue("@fpn", std.Std_FPhone);
                        cmd.Parameters.AddWithValue("@fcnic", std.Std_FCNIC);
                        cmd.Parameters.AddWithValue("@mname", std.Std_MName);
                        cmd.Parameters.AddWithValue("@mpn", std.Std_MPhone);
                        cmd.Parameters.AddWithValue("@mcnic", std.Std_MCNIC);
                        cmd.Parameters.AddWithValue("@address", std.Std_Address);
                        cmd.Parameters.AddWithValue("@class", std.Std_Class);
                        cmd.Parameters.AddWithValue("@section", std.Std_Section);
                        cmd.Parameters.AddWithValue("@enrollement_date", std.Std_EnrollmentDate);
                        cmd.Parameters.AddWithValue("@img", std.Std_Photo);
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
                    MessageBox.Show($"Error {ex}");
                }
            }
        }








        public void RemoveStudent(List<int> ids)
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
                            using (SqlCommand command = new SqlCommand("DELETE Student WHERE StudentID = @id", connection, transaction))
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



        public void UpdateStudent(int id,Student s)
        {
            /* bool check = false;
             foreach (Student std in Students)
             {
                 if (std.Student_ID == id)
                 {
                     RemoveStudent(std);
                     AddStudent(student);
                     check = true;
                     break;
                 }

             }

             if (!check)
             {
                 MessageBox.Show("User not found");
             }*/
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE Student SET StudentID = @newid, Std_Session = @session, Std_Name = @name, " +
                            "Std_Age = @age, Std_Gender = @gender, Std_DOB = @dob, Std_Disability = @disability, Std_BForm = @bform, " +
                            "Std_FName = @fname, Std_FPhone = @fphone, Std_FCNIC = @fcnic, Std_MName = @mname, Std_MPhone = @mphone, " +
                            "Std_MCNIC = @mcnic, Std_Address = @address, Std_Class = @class, Std_Section = @section, " +
                            "Std_EnrollementDate = @enrollement_date, Std_Photo = @photo  WHERE StudentID = @id", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@newid", s.StudentID); 
                            command.Parameters.AddWithValue("@session", s.Std_Session); 
                            command.Parameters.AddWithValue("@name", s.Name);
                            command.Parameters.AddWithValue("@age", s.Age); 
                            command.Parameters.AddWithValue("@gender", s.Gender); 
                            command.Parameters.AddWithValue("@dob", s.DOB); 
                            command.Parameters.AddWithValue("@disability", s.Disablity); 
                            command.Parameters.AddWithValue("@bform", s.Std_BForm); 
                            command.Parameters.AddWithValue("@fname", s.Std_FName); 
                            command.Parameters.AddWithValue("@fphone", s.Std_FPhone); 
                            command.Parameters.AddWithValue("@fcnic", s.Std_FCNIC);
                            command.Parameters.AddWithValue("@mname", s.Std_MName); 
                            command.Parameters.AddWithValue("@mphone", s.Std_MPhone); 
                            command.Parameters.AddWithValue("@mcnic", s.Std_MCNIC);
                            command.Parameters.AddWithValue("@address", s.Std_Address);
                            command.Parameters.AddWithValue("@class", s.Std_Class);
                            command.Parameters.AddWithValue("@section", s.Std_Section);
                            command.Parameters.AddWithValue("@enrollement_date", s.Std_EnrollmentDate);
                            command.Parameters.AddWithValue("@photo", s.Std_Photo);


                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show($"Student with ID: {id} has been updated with Ne ID: {s.StudentID}");
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
