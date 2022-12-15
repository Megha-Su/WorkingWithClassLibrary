using System;
using System.Collections.Generic;
using System.Text;

namespace Apo.net_Demo
{
    class Program
    {

        static void Main(string[] args)
        {
            //to read data from the database  

            var getData = new EmployeeRepository();
            var employees = getData.GetEmployeeData();

            foreach (var item in employees)
            {
                Console.WriteLine(item.Id + "    " + item.Name + "   " + item.Age);
            }

            try

            {
                var insertData = new EmployeeRepository();

                //to insert data
                insertData.CreateEmployeeTable(new Employee
                {
                    Name = "Mohan",
                    Age = 25,

                });

                //to Update data
                insertData.UpdateEmployeeTable(new Employee
                {
                    Name = "Nandu",
                    Id = 3,
                });

                //to delete  data
                insertData.DeleteEmployeeTable(4);
            }
            catch
            {
                throw;
            }
        }
    }
}

