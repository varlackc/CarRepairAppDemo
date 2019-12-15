using System.Collections.Generic;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    // Store Processor
    public static class StoreProcessor
    {
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

            string sql = @"Insert into dbo.[Store]( StoreName, StoreAddress, PhoneNumber, HoursOfOperation)
                           Values ( @StoreName, @StoreAddress, @PhoneNumber, @HoursOfOperation);";

            return SqlDataAccess.SaveData(sql, data);
        }

        //Read Part Data
        public static List<StoreModel>LoadStore()
       {

            //create SQL Query
            string sql = @"SELECT *
                           FROM dbo.[Store];";

            return SqlDataAccess.LoadData<StoreModel>(sql);
        }

        //Update Store Data
        public static void UpdateStore(int storeId, string storeName, string storeAddress, string phoneNumber,
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

            //create SQL Query
            string sql = @"Update dbo.[Store]
                           SET StoreId = @StoreId, StoreName = @StoreName, StoreAddress = @StoreAddress, 
                               PhoneNumber = @PhoneNumber, HoursOfOperation = @HoursOfOperation
                           WHERE StoreId = @StoreId;";

            SqlDataAccess.UpdateData(sql, data);
        }


        //Delete Order
        public static void DeleteStore(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[Store] WHERE StoreId = @id;";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }
    }
}
