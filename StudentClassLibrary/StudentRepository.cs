using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudentClassLibrary
{
    public class StudentRepository
    {
        private readonly SqlConnection sqlConnection;
        public StudentRepository()
        {
            var connectionString = "data source= (localdb)\\mssqllocaldb; database= TrainingDb;";
            sqlConnection = new SqlConnection(connectionString);
        }

        public bool InsertinStudentTable(StudentClass student)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("insert into StudentsTable values(@name,@dept)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", student.Name);

                sqlCommand.Parameters.AddWithValue("dept", student.Department);

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public bool UpdateinStudentTable(StudentClass student)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("update StudentsTable set Name= @name where Rollno=@rollnum", sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", student.Name);

                sqlCommand.Parameters.AddWithValue("rollnum", student.RollNo);

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public bool DeleteinStudentTable(int Roll)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("delete from StudentsTable where Rollno=@rollnum", sqlConnection);

                sqlCommand.Parameters.AddWithValue("rollnum", Roll);

                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

    }
}