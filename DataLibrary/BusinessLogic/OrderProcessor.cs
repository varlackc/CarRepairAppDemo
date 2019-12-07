﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class OrderProcessor
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
        public static List<OrderModel> LoadOrder(int id)
        {
            //create SQL Query
            string sql = @"SELECT *
                           FROM dbo.[Order];";

            return SqlDataAccess.LoadData<OrderModel>(sql);
        }


        //Update Order Data
        public static void UpdateOrder(int clientId, int storeId, int employeeId, DateTime orderTime,
                                    string orderType, string orderSpecifications, string description,
                                    string location, string status)
        {
            PartModel data = new PartModel
            {
                PartId = partId,
                PartName = partName,
                PartDescription = partDescription,
                PartNumber = partName,
                PartSupplier = partSupplier,
                PartCost = partCost,
                PartPrice = partPrice
            };

            //create SQL Query
            string sql = @"Update dbo.[Part]
                           SET PartName = @PartName, PartDescription = @PartDescription, PartNumber = @PartNumber, 
                               PartSupplier = @PartSupplier, PartCost = @PartCost, PartPrice = @PartPrice
                           WHERE PartId = @PartId;";

            SqlDataAccess.UpdateData(sql, data);
        }

        //Delete Order
        public static void DeleteOrder(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[Order] WHERE OrderId = @id";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }
    }
}
