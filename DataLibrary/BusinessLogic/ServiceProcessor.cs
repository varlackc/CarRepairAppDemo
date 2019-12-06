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
        //create new Service

        public static int CreateService(int storeId, string storeName, string storeAddress, string phoneNumber,
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

            string sql = @"Insert into dbo.[Store](StoreId, StoreName, StoreAddress, PhoneNumber, HoursOfOperation) *
                           Values (@StoreId, @StoreName, @StoreAddress, @PhoneNumber, @HoursOfOperation);";

            return SqlDataAccess.SaveData(sql, data);
        }

        //Read Part Data
        public static List<PartModel> LoadService()
        {

            //create SQL Query
            string sql = @"SELECT *
                           FROM dbo.[Part];";

            return SqlDataAccess.LoadData<PartModel>(sql);
        }

        //Update Store Data
        public static void UpdateService(int storeId, string storeName, string storeAddress, string phoneNumber,
                                     string hoursOfOperation)
        {
            PartModel data = new PartModel
            {
                StoreId = sotreId,
                StoreName = storeName,
                StoreAddress = storeAddress,
                PhoneNumber = phoneNumber,
                HoursOfOperation = hoursOfOperation
            };

            //create SQL Query
            string sql = @"Update dbo.[Part]
                           SET StoreId = @StoreId, StoreName = @StoreName, StoreAddress = @StoreAddress, 
                               PhoneNumber = @PhoneNumber, HoursOfOperation = @HoursOfOperation
                           WHERE StoreId = @StoreId;";

            SqlDataAccess.UpdateData(sql, data);
        }


        //Delete Order
        public static void DeleteService(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[Store] WHERE StoreId = @id";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }
    }
}
