using StudentClassLibrary;
using System;

namespace StudentMain
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var DataOperations = new StudentRepository();
                //DataOperations.InsertinStudentTable(new StudentClass
                //{

                //    Name = "Nithin",
                //    Department = "MSc"

                //});

                //DataOperations.UpdateinStudentTable(new StudentClass
                //{
                //   Name = "Rahul",
                //   RollNo = 1,

                //});

                DataOperations.DeleteinStudentTable(3);


            }
            catch (Exception exception)
            {
                throw;
            }


        }
    }
}
