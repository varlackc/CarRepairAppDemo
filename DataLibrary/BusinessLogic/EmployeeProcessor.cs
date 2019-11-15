using DataLibrary.Models;
using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeeProcessor
    {
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
                //EmailAddress = emailAddress

            };

            string sql = @"insert into db.Employee (EmployeeId, UserName, FirstName, LastName, Location, PhoneNumber, Status)
                            values (@EmployeeId, @UserName, @FirstName, @LastName, @Location, @PhoneNumber, @Status);";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
