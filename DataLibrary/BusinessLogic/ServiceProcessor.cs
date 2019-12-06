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

        public static int CreateService(int serviceId, string serviceName, string serviceDescription, DateTime serviceDate,
                                      string status)
        {
            ServiceModel data = new ServiceModel
            {
                ServiceId = serviceId,
                ServiceName = serviceName,
                ServiceDescription = serviceDescription,
                ServiceDate = serviceDate,
                Status = status
            };

            string sql = @"Insert into dbo.[Service](ServiceId, ServiceName, ServiceDescription, ServiceDate, 
                                                     Status)
                           Values (@ServiceId, @ServiceName, @ServiceDescription, @ServiceDate, @Status);";

            return SqlDataAccess.SaveData(sql, data);
        }

        //Read Part Data
        public static List<ServiceModel> LoadService()
        {

            //create SQL Query
            string sql = @"SELECT *
                           FROM dbo.[Service];";

            return SqlDataAccess.LoadData<ServiceModel>(sql);
        }

        //Update Store Data
        public static void UpdateService(int serviceId, string serviceName, string serviceDescription, DateTime serviceDate,
                                      string status)
        {
            ServiceModel data = new ServiceModel
            {
                ServiceId = serviceId,
                ServiceName = serviceName,
                ServiceDescription = serviceDescription,
                ServiceDate = serviceDate,
                Status = status
            };

            //create SQL Query
            string sql = @"Update dbo.[Service]
                           SET ServiceId = @ServiceId, ServiceName = @ServiceName, 
                        ServiceDescription = @ServiceDescription, ServiceDate = @ServiceDate,Status = @Status
                           WHERE ServiceId = @ServiceId;";

            SqlDataAccess.UpdateData(sql, data);
        }


        //Delete Order
        public static void DeleteService(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[Service] WHERE ServiceId = @id";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }
    }
}
