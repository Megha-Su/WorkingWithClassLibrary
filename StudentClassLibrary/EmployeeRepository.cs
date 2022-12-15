using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;

namespace Apo.net_Demo
{
    public class EmployeeRepository
    {
        private readonly SqlConnection sqlConnection;
        public EmployeeRepository()
        {
            var connectionString = "data source =(localdb)\\mssqllocaldb;database=TrainingDb;";

            sqlConnection = new SqlConnection(connectionString);
        }
        public IEnumerable<Employee> GetEmployeeData()
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Select * from EmployeeTable", sqlConnection);

                var employeeList = new List<Employee>();

                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())

                {
                    employeeList.Add(new Employee
                    {
                        Id = (int)sqlDataReader["Id"],
                        Name = (string)sqlDataReader["Name"],
                        Age = (int)sqlDataReader["Age"]

                    });
                }
                return employeeList;

            }

            catch (Exception exception)
            {
                throw;
                Console.WriteLine(exception);
            }

            finally
            { 

             sqlConnection.Close();
             
            }
        }

        public bool CreateEmployeeTable(Employee employee) 
        {
            try
            {

                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Insert into EmployeeTable values(@name ,@age)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", employee.Name);

                sqlCommand.Parameters.AddWithValue("age", employee.Age);

                sqlCommand.ExecuteNonQuery();

                return true;
            }

            catch(Exception expMsg)
            {
                Console.WriteLine(expMsg.Message);

                return false;
            }
            finally
            {
               sqlConnection.Close();
            }

        }
        public bool UpdateEmployeeTable(Employee employee)
        {

            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Update EmployeeTable set Name = @name where Id = @id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", employee.Name);

                sqlCommand.Parameters.AddWithValue("id", employee.Id);

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception expMsg)
            {
                Console.WriteLine(expMsg.Message);

                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
      
        }
        public bool DeleteEmployeeTable(int id)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Delete from EmployeeTable where Id = @id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("id", id);

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception expMsg)
            {
                Console.WriteLine(expMsg.Message);

                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }

}