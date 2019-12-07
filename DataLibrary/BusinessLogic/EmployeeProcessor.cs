using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeeProcessor
    {
        // Create New Employee
        public static int CreateEmployee(int employeeId, string userName, string firstName, string lastName,
                                        string location, string phoneNumber, string status)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                Location = location,
                PhoneNumber = phoneNumber,
                Status = status
            };

            string sql = @"insert into db.Employee (UserName, FirstName, LastName, Location, PhoneNumber, Status)
                            values (@UserName, @FirstName, @LastName, @Location, @PhoneNumber, @Status);";

            return SqlDataAccess.SaveData(sql, data);
        }

        // read employee data
        public static List<EmployeeModel> LoadEmployee()
        {
            //create SQL Query
            string sql = @"SELECT * 
                           FROM dbo.[Employee];";

            // load the data access to call the employee data
            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }
        public static EmployeeModel LoadOneEmployee(int id)
        {

            //create SQL Query
            string sql = @"SELECT * 
                           FROM dbo.[Employee]
                           WHERE Id = @id;";
            return SqlDataAccess.LoadOne<EmployeeModel>(sql, id);
        }


        //Update Employee Data
        public static void UpdateEmployee(int employeeId, string userName, string firstName, string lastName,
                                        string location, string phoneNumber, string status)
        {

            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                Location = location,
                PhoneNumber = phoneNumber,
                Status = status
            };

            //create SQL Query
            string sql = @"Update dbo.[Order]
                           SET UserName = @UserName, FirstName = @FirstName, LastName = @LastName, 
                               Location = @Location, PhoneNumber = @PhoneNumber, Status = @Status
                           WHERE EmployeeId = @EmployeeId;";

            SqlDataAccess.UpdateData(sql, data);
        }


        //Delete Employee Method
        public static void DeleteEmployee(int id)
        {

            //create the sql command
            string sql = @"DELETE FROM dbo.[Employee] WHERE Id = @id";

            //call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }
    }
}
