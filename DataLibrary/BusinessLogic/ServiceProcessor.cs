using System;
using System.Collections.Generic;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    // Service Processor
    public static class ServiceProcessor
    {
        //create new Service

        public static int CreateService(int serviceId, string serviceName, string serviceDescription, DateTime serviceDate,
                                      string status, string serviceType)
        {
            ServiceModel data = new ServiceModel
            {
                ServiceId = serviceId,
                ServiceName = serviceName,
                ServiceDescription = serviceDescription,
                ServiceDate = serviceDate,
                Status = status,
                ServiceType = serviceType
            };

            string sql = @"Insert into dbo.[Service](ServiceName, ServiceDescription, ServiceDate, 
                                                     Status, ServiceType)
                           Values (@ServiceName, @ServiceDescription, @ServiceDate, @Status, 
                                    @ServiceType);";

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

        public static ServiceModel LoadOneService(int id)
        {
            // Create SQL Query
            string sql = @"SELECT * 
                           FROM dbo.[Service]
                           WHERE ServiceId = @id;";
            return SqlDataAccess.LoadOne<ServiceModel>(sql, id);
        }

        //Update Store Data
        public static void UpdateService(int serviceId, string serviceName, string serviceDescription, DateTime serviceDate,
                                      string status, string serviceType)
        {
            ServiceModel data = new ServiceModel
            {
                ServiceId = serviceId,
                ServiceName = serviceName,
                ServiceDescription = serviceDescription,
                ServiceDate = serviceDate,
                Status = status,
                ServiceType = serviceType
            };

            //create SQL Query
            string sql = @"Update dbo.[Service]
                           SET ServiceName = @ServiceName, 
                        ServiceDescription = @ServiceDescription, ServiceDate = @ServiceDate,Status = @Status, 
                            ServiceType = @ServiceType
                           WHERE ServiceId = @ServiceId;";

            SqlDataAccess.UpdateData(sql, data);
        }


        //Delete Order
        public static void DeleteService(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[Service] WHERE ServiceId = @id;";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }
    }
}
