using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    // Service Processor
    public static class ServiceProcessor
    {
        //create new part
        /*
        public static int CreateService(int partId, string partName, string partDescription, string partNumber,
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

            return SqlDataAccess.SaveData(sql, data);
        }

        //Read Part Data
        public static List<PartModel> LoadPart()
        {

            //create SQL Query
            string sql = @"SELECT *
                           FROM dbo.[Part];";

            return SqlDataAccess.LoadData<PartModel>(sql);
        }

        //Delete Order
        public static void DeletePart(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[Part] WHERE PartId = @id";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }

        */
    }
}
