using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdTech
{
    public class TimeTableRepo
    {
        private string connectionString = "";
        public List<TimeTable> TimeTables;
        public TimeTableRepo(string connectionString)
        {
            this.connectionString = connectionString;
            TimeTables = new List<TimeTable>();
        }

        public List<int> getClassNumbers()
        {
            List<int> classNum = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
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
        public void AddTimetableEntry(List<TimeTable> entries)
        {
            foreach (TimeTable entry in entries)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    try
                    {

                        string query = "INSERT INTO Timetable (TDay, StartTime, EndTime, CGrade, Subject) VALUES (@Day, @StartTime, @EndTime, @class, @Subject)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Day", (int)entry.Day);
                            command.Parameters.AddWithValue("@StartTime", entry.StartTime);
                            command.Parameters.AddWithValue("@EndTime", entry.EndTime);
                            command.Parameters.AddWithValue("@Subject", entry.Subject);
                            command.Parameters.AddWithValue("@class", entry.CGrade);

                            command.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException e)
                    {
                        if (e.Number == 547)
                        {
                            MessageBox.Show($"Foreign key constraint violation. The value for Grade: {entry.CGrade} does not exist in S_Class.");
                        }
                        else
                        {
                            MessageBox.Show($"SQL Exception: {e.Message}");
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Exception: {e.Message}");
                    }
                }
            }
        }

        public List<TimeTable> GetTimetableForDay(DayOfWeek day, int c)
        {
            TimeTables.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Timetable WHERE TDay = @Day AND CGrade = @n";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Day", day);
                    command.Parameters.AddWithValue("@n", c);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeTable entry = new TimeTable
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Day = (DayOfWeek)reader.GetInt32(reader.GetOrdinal("TDay")),
                                StartTime = reader.GetTimeSpan(reader.GetOrdinal("StartTime")),
                                EndTime = reader.GetTimeSpan(reader.GetOrdinal("EndTime")),
                                CGrade = reader.GetInt32(reader.GetOrdinal("CGrade")),
                                Subject = reader.GetString(reader.GetOrdinal("Subject"))
                            };

                            TimeTables.Add(entry);
                        }
                    }
                }
            }

            return TimeTables;
        }
        public void RemoveTimeTable(List<int> ids)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int rowsAffected = 0;

                        foreach (int id in ids)
                        {
                            using (SqlCommand command = new SqlCommand("DELETE Timetable WHERE Id = @id", connection, transaction))
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

        public void UpdateTimetable(DayOfWeek d, int g, string s, TimeTable entry)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE Timetable SET TDay = @Day, StartTime = @StartTime," +
                            " EndTime = @EndTime, CGrade = @class, Subject = @Subject WHERE TDay = @d AND CGrade = @g AND Subject = @s", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Day", (int)entry.Day);
                            command.Parameters.AddWithValue("@StartTime", entry.StartTime);
                            command.Parameters.AddWithValue("@EndTime", entry.EndTime);
                            command.Parameters.AddWithValue("@Subject", entry.Subject);
                            command.Parameters.AddWithValue("@class", entry.CGrade);
                            command.Parameters.AddWithValue("@d", (int)d);
                            command.Parameters.AddWithValue("@g", g);
                            command.Parameters.AddWithValue("@s", s);







                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                               MessageBox.Show("Updated Successfully");
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                                MessageBox.Show("Transaction rolled back: No rows affected");
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
