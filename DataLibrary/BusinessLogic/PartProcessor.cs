﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public class PartProcessor
    {
        //create new part
        public static int CreatePart(int partId, string partName, string partDescription, string partNumber, 
                                     string partSupplier, decimal partCost, decimal partPrice)
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

            string sql = @"SELECT *
                           FROM dbo.[Part];";

            return SqlDataAccess.LoadData<PartModel>(sql);
        }

        //Read Part Data
        public static List<PartModel>LoadPart()
       {

       }

        //Delete Order
        public static void DeletePart(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[Order] WHERE OrderId = @id";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }
    }
}
