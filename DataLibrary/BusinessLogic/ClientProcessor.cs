using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class ClientProcessor
    {
        //Create New Client
        public static int CreateClient(int clientId, string userName, string firstName, string lastName, 
                                        string location, string phoneNumber, string status)
        {
            ClientModel data = new ClientModel {
                ClientId = clientId,
                UserName = userName, 
                FirstName = firstName, 
                LastName = lastName, 
                Location = location, 
                PhoneNumber = phoneNumber, 
                Status = status
            };

            string sql = @"insert into dbo.[Client] (UserName, FirstName, LastName, Location, PhoneNumber, Status)
                            values (@UserName, @FirstName, @LastName, @Location, @PhoneNumber, @Status);";

            return SqlDataAccess.SaveData(sql, data);
        }

        // Read Client Data
        public static List<ClientModel> LoadClient()
        {
            //Create SQL Query
            string sql = @"SELECT *
                            FROM dbo.[Client];";

            //load the data access to call the client data
            return SqlDataAccess.LoadData<ClientModel>(sql);
        }
        public static List<ClientModel> LoadOneClient(int id)
        {
            //Create SQL Query
            string sql = @"SELECT *
                            FROM dbo.[Client]
                            WHERE ClientId = @id;";

            //load the data access to call the client data
            return SqlDataAccess.LoadData<ClientModel>(sql);
        }


        //Update Client Data
        public static void UpdateClient(int clientId, string userName, string firstName, string lastName,
                                        string location, string phoneNumber, string status)
        {

            ClientModel data = new ClientModel
            {
                ClientId = clientId,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                Location = location,
                PhoneNumber = phoneNumber,
                Status = status
            };

            //create SQL Query
            string sql = @"Update dbo.[Client]
                           SET UserName = @UserName, FirstName = @FirstName, LastName = @LastName, 
                               Location = @Location, PhoneNumber = @PhoneNumber, Status = @Status
                           WHERE ClientId = @ClientId;";

            SqlDataAccess.UpdateData(sql, data);
        }


        //Delete Client Method
        public static void DeleteClient(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[Client] WHERE ClientId = @id";

            //call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }
    }
}
