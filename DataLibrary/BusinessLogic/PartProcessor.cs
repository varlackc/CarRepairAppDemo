using System;
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

            string sql = @"Insert into dbo.[Part] (PartId, PartName, PartDescription, PartNumber, PartSupplier, PartCost, PartPrice)
                           Values (@PartId, @PartName, @PartDescription, @PartNumber, @PartSupplier, @PartCost, @PartPrice);";

            return SqlDataAccess.SaveData(sql, data);
        }

        //Read Part Data
        public static List<PartModel>LoadPart()
       {

            //create SQL Query
            string sql = @"SELECT *
                           FROM dbo.[Part];";

            return SqlDataAccess.LoadData<PartModel>(sql);
        }

        //Update Part Data
        public static void UpdatePart(int partId, string partName, string partDescription, string partNumber,
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

            //create SQL Query
            string sql = @"Update dbo.[Part]
                           SET PartName = @PartName, PartDescription = @PartDescription, PartNumber = @PartNumber, 
                               PartSupplier = @PartSupplier, PartCost = @PartCost, PartPrice = @PartPrice
                           WHERE PartId = @PartId;";

            SqlDataAccess.UpdateData(sql, data);
        }


        //Delete Order
        public static void DeletePart(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[Part] WHERE PartId = @id;";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }
    }
}
