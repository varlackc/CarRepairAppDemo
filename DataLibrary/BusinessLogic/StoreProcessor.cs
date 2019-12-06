using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    // Store Processor
    public static class StoreProcessor
    {
        /*
         //create new Store
        public static int CreateStore(int storeId, string storeName, string storeAddress, string phoneNumber,
                                      string hoursOfOperation)
        {
            StoreModel data = new StoreModel
            {
                StoreId = storeId,
                StoreName = storeName,
                StoreAddress = storeAddress,
                PhoneNumber = phoneNumber,
                HoursOfOperation = hoursOfOperation
            };

            string sql = @"SELECT *
                           FROM dbo.[Store];";

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
