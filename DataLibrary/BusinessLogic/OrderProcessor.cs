using System;
using System.Collections.Generic;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class OrderProcessor
    {
        //Create new Order
        public static int CreateOrder(int clientId, int storeId, int employeeId, DateTime orderTime, 
                                    string orderType, string orderSpecifications, string description, 
                                    string location, string status)
        {
            OrderModel data = new OrderModel
            {
                ClientId = clientId, 
                StoreId = storeId,
                EmployeeId = employeeId, 
                OrderTime = orderTime, 
                OrderType = orderType, 
                OrderSpecifications = orderSpecifications, 
                Description = description, 
                Location = location, 
                Status = status
                //OrderLine = List<OrderLineModel> 
            };
            string sqlHeading = @"INSERT INTO dbo.[Order] (ClientId, StoreId, EmployeeId, OrderTime, OrderType, 
                                                    Specifications, [Description], [Location], [Status])
                                        VALUES (@ClientId, @StoreId, @EmployeeId, @OrderTime, @OrderType, 
                                                    @OrderSpecifications, @Description, @Location, @Status);";

            return SqlDataAccess.SaveData(sqlHeading, data);

        }

        //Create new Order
        public static int CreateOrderLine(int orderLineId, int orderId, int partId, int serviceId,
                                    int lineNo, string lineDescription, int serviceQty, int partQty,
                                    string status, string orderNotes, string partName, string serviceName)
        {
            OrderLineModel data = new OrderLineModel
            {
                OrderLineId = orderLineId,
                OrderId = orderId,
                PartId = partId,
                ServiceId = serviceId,
                LineNo = lineNo,
                LineDescription = lineDescription,
                ServiceQty = serviceQty,
                PartQty = partQty,
                Status = status,
                OrderNotes = orderNotes,
                PartName = partName,
                ServiceName = serviceName
            };
            string sqlBody = @"INSERT INTO dbo.[Order] (OrderLineId, OrderId, PartId, ServiceId, LineNo, LineDescription, ServiceQty, PartQty, 
                                                            [Status], OrderNotes, PartName, ServiceName)
                                        VALUES (@OrderLineId, @OrderId, @PartId, @ServiceId, @LineNo, @LineDescription, @ServiceQty, @PartQty, 
                                                    @Status, @OrderNotes, @PartName, @ServiceName);";

            return SqlDataAccess.SaveData(sqlBody, data);

        }


        // Read Order
        public static List<OrderModel> LoadOrder()
        {
            //create SQL Query
            string sql = @"SELECT *
                           FROM dbo.[Order];";

            return SqlDataAccess.LoadData<OrderModel>(sql);
        }

        public static List<Order2Model> LoadOrder2()
        {
            //create SQL Query
            string sql = @"
            SELECT  dbo.[Order].OrderId, dbo.[Client].UserName AS ClientName,
                dbo.[Store].StoreName, 
                dbo.[Employee].UserName AS EmployeeName,
                dbo.[Order].OrderTime, dbo.[Order].OrderType, 
                dbo.[Order].Specifications, dbo.[Order].[Description],
                dbo.[Order].[Location], dbo.[Order].[Status],
                dbo.[OrderLine].OrderLineId,
                dbo.[OrderLine].PartId, dbo.[OrderLine].ServiceId, 
                dbo.[OrderLine].[LineNo], dbo.[OrderLine].LineDescription,
                dbo.[OrderLine].ServiceQty, dbo.[OrderLine].PartQty,
                dbo.[OrderLine].[Status], dbo.[OrderLine].OrderNotes
            FROM ((((dbo.[ORDER]
                INNER JOIN dbo.[ORDERLINE] ON dbo.[ORDER].OrderId = dbo.[ORDERLINE].OrderId)
                INNER JOIN dbo.[Client] ON dbo.[Order].ClientId = dbo.[Client].ClientId)
                INNER JOIN dbo.[Store] ON dbo.[ORDER].StoreId = dbo.[Store].StoreId)
                INNER JOIN dbo.[Employee] ON dbo.[ORDER].EmployeeId = dbo.[Employee].EmployeeId);";

            return SqlDataAccess.LoadData<Order2Model>(sql);
        }


        public static OrderModel LoadOneOrder(int id)
        {

            //create SQL Query
            string sqlHeader = @"SELECT * 
                           FROM dbo.[Order]
                           WHERE OrderId = @id;";

            var orderHeader = SqlDataAccess.LoadOne<OrderModel>(sqlHeader, id);

            
            return orderHeader;

        }

        public static Order2Model LoadOneOrder2(int id)
        {

            //create SQL Query
            string sqlHeader = @"
            SELECT  dbo.[Order].OrderId, dbo.[Client].UserName AS ClientName,
                dbo.[Store].StoreName, 
                dbo.[Employee].UserName AS EmployeeName,
                dbo.[Order].OrderTime, dbo.[Order].OrderType, 
                dbo.[Order].Specifications, dbo.[Order].[Description],
                dbo.[Order].[Location], dbo.[Order].[Status],
                dbo.[OrderLine].OrderLineId,
                dbo.[OrderLine].PartId, dbo.[OrderLine].ServiceId, 
                dbo.[OrderLine].[LineNo], dbo.[OrderLine].LineDescription,
                dbo.[OrderLine].ServiceQty, dbo.[OrderLine].PartQty,
                dbo.[OrderLine].[Status], dbo.[OrderLine].OrderNotes
            FROM ((((dbo.[ORDER]
                INNER JOIN dbo.[ORDERLINE] ON dbo.[ORDER].OrderId = dbo.[ORDERLINE].OrderId)
                INNER JOIN dbo.[Client] ON dbo.[Order].ClientId = dbo.[Client].ClientId)
                INNER JOIN dbo.[Store] ON dbo.[ORDER].StoreId = dbo.[Store].StoreId)
                INNER JOIN dbo.[Employee] ON dbo.[ORDER].EmployeeId = dbo.[Employee].EmployeeId)
            WHERE dbo.[ORDER].OrderId = @id;";

            var orderHeader = SqlDataAccess.LoadOne<Order2Model>(sqlHeader, id);


            return orderHeader;

        }

        public static OrderStructureModel LoadOneOrderStructure(int id)
        {

            //create SQL Query
            string sqlHeader = @"SELECT * 
                           FROM dbo.[Order]
                           WHERE OrderId = @id;";

            string sqlBody = @"SELECT *
                           FROM dbo.[OrderLine]
                           WHERE OrderId = @id;";

            var orderHeader = SqlDataAccess.LoadOne<OrderModel>(sqlHeader, id);

            var orderBody = SqlDataAccess.LoadData<OrderLineModel>(sqlBody, id);

            var order = new OrderStructureModel
            {
                OrderHeading = orderHeader,
                OrderBody = orderBody
            };

            return order;

        }


        public static OrderStructureModel LoadOneOrderStructure2(int id)
        {

            //create SQL Query
            string sqlHeader = @"

            SELECT dbo.[Order].* , dbo.[Client].UserName AS ClientName,
                dbo.[Store].StoreName, 
                dbo.[Employee].UserName AS EmployeeName
            FROM (((dbo.[Order]
                INNER JOIN dbo.[Client] ON dbo.[Order].ClientId = dbo.[Client].ClientId)
                INNER JOIN dbo.[Store] ON dbo.[Order].StoreId = dbo.[Store].StoreId)
                INNER JOIN dbo.[Employee] ON dbo.[Order].EmployeeId = dbo.[Employee].EmployeeId )
            WHERE dbo.[Order].OrderId = @id
                                            ;";

            string sqlBody = @"
            SELECT	dbo.[OrderLine].*, dbo.[Part].PartName, dbo.[Service].ServiceName
            FROM ((dbo.[OrderLine]
                INNER JOIN dbo.[Part] ON dbo.[OrderLine].PartId = dbo.[Part].PartId)
                INNER JOIN dbo.[Service] ON dbo.[OrderLine].ServiceId = dbo.[Service].ServiceId) 
            WHERE OrderId = @id;";

            var orderHeader = SqlDataAccess.LoadOne<OrderModel>(sqlHeader, id);

            var orderBody = SqlDataAccess.LoadData<OrderLineModel>(sqlBody, id);

            var order = new OrderStructureModel
            {
                OrderHeading = orderHeader,
                OrderBody = orderBody
            };

            return order;
        }

        public static OrderLineModel LoadOneLine(int id)
        {

            string sqlBody = @"
            SELECT	dbo.[OrderLine].*, dbo.[Part].PartName, dbo.[Service].ServiceName
            FROM ((dbo.[OrderLine]
                INNER JOIN dbo.[Part] ON dbo.[OrderLine].PartId = dbo.[Part].PartId)
                INNER JOIN dbo.[Service] ON dbo.[OrderLine].ServiceId = dbo.[Service].ServiceId) 
            WHERE OrderId = @id;";

            var orderBody = SqlDataAccess.LoadOne<OrderLineModel>(sqlBody, id);

            return orderBody;
        }

        //Update Order Data
        public static void UpdateOrder(int clientId, int storeId, int employeeId, DateTime orderTime,
                                    string orderType, string orderSpecifications, string description,
                                    string location, string status, string clientName, string storeName, 
                                    string employeeName)
        {
            OrderModel data = new OrderModel
            {
                ClientId = clientId,
                StoreId = storeId,
                EmployeeId = employeeId,
                OrderTime = orderTime,
                OrderType = orderType,
                OrderSpecifications = orderSpecifications,
                Description = description,
                Location = location, 
                Status = status,
                //------------------
                ClientName = clientName,
                StoreName = storeName,
                EmployeeName = employeeName
            };

            //create SQL Query
            string sql = @"Update dbo.[Order]
                           SET StoreId = @StoreId, EmployeeId = @EmployeeId, 
                               OrderTime = @OrderTime, OrderType = @OrderType, 
                               OrderSpecifications = @OrderSpecifications, Description = @Description
                               Location = @Location, Status = @Status, ClientName = @ClientName,
                               StoreName = @StoreName, EmployeeName = @EmployeeName
                           WHERE ClientId = @ClientId;";

            SqlDataAccess.UpdateData(sql, data);
        }

        public static void UpdateOneOrderLine(int orderLineId, int orderId, int partId, int serviceId, int lineNo, string lineDescription, 
                                                int serviceQty, int partQty, string status, string orderNote, string partName, string serviceName)
        {
            OrderLineModel data = new OrderLineModel
            {
                OrderLineId = orderLineId,
                OrderId = orderId,
                PartId = partId,
                ServiceId = serviceId,
                LineNo = lineNo, 
                LineDescription = lineDescription,
                ServiceQty = serviceQty,
                PartQty = partQty,
                Status = status,
                OrderNotes = orderNote,
                PartName = partName,
                ServiceName = serviceName
            };

            //create SQL Query
            string sql = @"Update dbo.[Order]
                           SET OrderLineId = @OrderLineId, OrderId = @OrderId, PartId = @PartId, ServiceId = @ServiceId, LineNo = @LineNo,
                               LineDescription = @LineDescription, ServiceQty = @ServiceQty, PartQty = @PartQty, Status = @Status, 
                               OrderNote = @OrderNote, PartName = @PartName, ServiceName = @ServiceName 
                           WHERE OrderLineId = @OrderLineId;";

            SqlDataAccess.UpdateData(sql, data);
        }

        //Delete Order
        public static void DeleteOrder(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[Order] WHERE OrderId = @id;";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }

        public static void DeleteOrderLines(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[OrderLine] WHERE OrderId = @id;";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }

        public static void DeleteOrderLineID(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.[OrderLine] WHERE OrderLineId = @id;";

            //Call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }

    }
}
