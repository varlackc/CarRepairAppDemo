using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class OrderLineProcessor
    {
        //Create New Order Line 
        public static int CreateOrderLine(int orderLineId, int orderID, int partId, int serviceId, int lineNo, 
                                            string lineDescription, int serviceQty, int partQty, string status, 
                                            string orderNotes)
        {
            OrderLineModel data = new OrderLineModel {
                OrderLineId = orderLineId, 
                OrderId = orderID, 
                PartId = partId, 
                ServiceId = serviceId, 
                LineNo = lineNo, 
                LineDescription = lineDescription, 
                ServiceQty = serviceQty, 
                PartQty = partQty, 
                Status = status, 
                OrderNotes = orderNotes
            };

            string sql = @"insert into dbo.OrderLine (OrderId, PartId, ServiceId, LineNo, LineDescription, 
                                                    ServiceQty, PartQty, Status, OrderNotes)";
            return SqlDataAccess.SaveData(sql, data);
        }

        //read order line data
        public static List<OrderLineModel> LoadOrderLine()
        {
            //create SQL Query
            string sql = @"SELECT *
                           FROM dbo.[OrderLine];";
            return SqlDataAccess.LoadData<OrderLineModel>(sql);
        }
        public static OrderLineModel LoadOneOrderLine(int id)
        {
            //create SQL Query
            string sql = @"SELECT *
                            FROM dbo.[OrderLine]
                            WHERE Id = @id;";
            return SqlDataAccess.LoadOne<OrderLineModel>(sql, id);
        }

        //Delete OrderLine Method
        public static void DeleteOrderLine(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[OrderLine] WHERE Id = @id";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }
    }
}
