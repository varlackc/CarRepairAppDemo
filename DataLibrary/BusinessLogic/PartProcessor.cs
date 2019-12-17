using System.Collections.Generic;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public class PartProcessor
    {
        //create new part
        public static int CreatePart(int partId, string partName, string partDescription, string partNumber, 
                                     string partSupplier, decimal partCost, decimal partPrice, string partManufacturer)
        {
            PartModel data = new PartModel
            {
                PartId = partId,
                PartName = partName,
                PartDescription = partDescription,
                PartNumber = partNumber,
                PartSupplier = partSupplier,
                PartCost = partCost,
                PartPrice = partPrice,
                PartManufacturer = partManufacturer
            };

            string sql = @"Insert into dbo.[Part] (PartName, PartDescription, PartNumber, PartSupplier, PartCost, PartPrice, PartManufacturer)
                           Values (@PartName, @PartDescription, @PartNumber, @PartSupplier, @PartCost, @PartPrice, PartManufacturer);";

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

        public static PartModel LoadOnePart(int id)
        {

            //create SQL Query
            string sql = @"SELECT *
                           FROM dbo.[Part]
                           WHERE PartId = @id;";

            return SqlDataAccess.LoadOne<PartModel>(sql, id);
        }

        //Update Part Data
        public static void UpdatePart(int partId, string partName, string partDescription, string partNumber,
                                     string partSupplier, decimal partCost, decimal partPrice, string partManufacturer)
        {
            PartModel data = new PartModel
            {
                PartId = partId,
                PartName = partName,
                PartDescription = partDescription,
                PartNumber = partNumber, //Make sure that the field are matched and ordered properly
                PartSupplier = partSupplier,
                PartCost = partCost,
                PartPrice = partPrice,
                PartManufacturer = partManufacturer
            };

            //create SQL Query
            string sql = @"Update dbo.[Part]
                           SET PartName = @PartName, PartDescription = @PartDescription, PartNumber = @PartNumber, 
                               PartSupplier = @PartSupplier, PartCost = @PartCost, PartPrice = @PartPrice, 
                               PartManufacturer = @PartManufacturer
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
