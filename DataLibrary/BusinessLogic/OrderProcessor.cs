using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    class OrderProcessor
    {
        //Create new Order
        public static int CreateOrder(int clientId, int storeId, int employeeId, DateTime orderTime, 
                                    string orderType, string orderSpecifications, string description, 
                                    string location, string status)
        {
            OrderModel data = new OrderModel
            {
                ClientId = clientId, 
                StoreId = storeId,
                EmployeeId = employeeId, 
                OrderTime = orderTime, 
                OrderType = orderType, 
                OrderSpecifications = orderSpecifications, 
                Description = description, 
                Location = location, 
                Status = status
            };
            string sql = @"insert into dbo.[Order] (ClientId, StoreId, EmployeeId, OrderTime, OrderType, 
                                                    OrderSpecifications, Description, Location, Status)";
            return SqlDataAccess.SaveData(sql, data);
        }

        // Read Order
        public static List<OrderModel> LoadOrder(int clientId, int storeId, int employeeId, DateTime orderTime,
                                    string orderType, string orderSpecifications, string description,
                                    string location, string status)
        {
            OrderModel data = new OrderModel
            {
                ClientId = clientId,
                StoreId = storeId,
                EmployeeId = employeeId,
                OrderTime = orderTime,
                OrderType = orderType,
                OrderSpecifications = orderSpecifications,
                Description = description,
                Location = location,
                Status = status
            };

            string sql = @"
        }

        //Delete Order
        public static void DeleteOrder(int id)
        {

        }
    }
}
