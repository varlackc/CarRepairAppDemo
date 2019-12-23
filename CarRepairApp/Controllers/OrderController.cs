using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarRepairApp.Models;
using static DataLibrary.BusinessLogic.OrderProcessor;
using static DataLibrary.BusinessLogic.OrderLineProcessor;
//using DataLibrary.BusinessLogic;

namespace CarRepairApp.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult OrderList()
        {
            var data = LoadOrder(); //load the data
            List<OrderModel> orders = new List<OrderModel>(); //create a list of projects
            List<OrderLineModel> orderLines = new List<OrderLineModel>();
            foreach (var row in data) // loop to organize the data in the projects list
            {
                orders.Add(new OrderModel
                {
                    OrderId = row.OrderId,
                    ClientId = row.ClientId,
                    StoreId = row.StoreId,
                    EmployeeId = row.EmployeeId,
                    OrderTime = row.OrderTime,
                    OrderType = row.OrderType,
                    OrderSpecifications = row.OrderSpecifications,
                    Description = row.Description,
                    Location = row.Location,
                    Status = row.Status,
                    //List < OrderLineModel > OrderLine = new List<OrderLineModel>();
                
                });
            }
            return View(orders);
        }

        public ActionResult OrderList2()
        {
            var data = LoadOrder2(); //load the data
            List<Order2Model> orders = new List<Order2Model>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
            {
                orders.Add(new Order2Model
                {
                    OrderId = row.OrderId,
                    ClientId = row.ClientId,
                    ClientName = row.ClientName,
                    UserName = row.UserName,
                    StoreId = row.StoreId,
                    StoreName = row.StoreName,
                    EmployeeId = row.EmployeeId,
                    EmployeeName = row.EmployeeName,
                    OrderTime = row.OrderTime,
                    OrderType = row.OrderType,
                    Specifications = row.Specifications,
                    OrderSpecifications = row.OrderSpecifications,
                    Description = row.Description,
                    Location = row.Location,
                    Status = row.Status,
                    OrderLineId = row.OrderLineId,
                    PartId = row.PartId,
                    ServiceId = row.ServiceId,
                    LineDescription = row.LineDescription,
                    ServiceQty = row.ServiceQty,
                    PartQty = row.PartQty,
                    OrderNotes = row.OrderNotes
                    //List < OrderLineModel > OrderLine = new List<OrderLineModel>();

                });
            }
            return View(orders);
        }

        public ActionResult OrderList3(int id)
        {
            var data = LoadOneOrderStructure2(id); //load the data
            OrderStructureModel orders = new OrderStructureModel(); //create a list of projects
            orders.OrderHead.ClientId = data.OrderHeading.ClientId;
          
            return View(orders);
        }

        public ActionResult OrderDetail3(int id)
        {
            var data = LoadOneOrderStructure2(id); //load the data

            return View(data);
        }
    

        public ActionResult OrderDetails(int id)
        {
            //load the complete order
            var order = LoadOneOrder(id);
            
            var FinalOrder = new OrderModel
            {
                OrderId = order.OrderId,
                ClientId = order.ClientId,
                StoreId = order.StoreId,
                EmployeeId = order.EmployeeId,
                OrderTime = order.OrderTime,
                OrderType = order.OrderType,
                OrderSpecifications = order.OrderSpecifications,
                Description = order.Description,
                Location = order.Location,
                Status = order.Status,
                //List<OrderLineModel> OrderBody = orderLineList.Where( c => c.OrderId == order.OrderId ).ToList();
            };
            

            return View(FinalOrder);
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Message = "Order";
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                //Note: When calling a method, the order of the parameters is very important
                int recordsCreated = CreateOrder(model.ClientId, model.StoreId, model.EmployeeId, 
                                                 model.OrderTime, model.OrderType, model.OrderSpecifications, 
                                                 model.Description, model.Location, model.Status);

                return RedirectToAction("OrderList");
            }
            ViewBag.Message = "Order List";
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var resultModel = LoadOneOrder2(id);
            OrderModel orderModel = new OrderModel();

            orderModel.OrderId = resultModel.OrderId;
            orderModel.ClientId = resultModel.ClientId;
            orderModel.StoreId = resultModel.StoreId;
            orderModel.EmployeeId = resultModel.EmployeeId;
            orderModel.OrderTime = resultModel.OrderTime;
            orderModel.OrderType = resultModel.OrderType;
            orderModel.OrderSpecifications = resultModel.OrderSpecifications;
            orderModel.Description = resultModel.Description;
            orderModel.Location = resultModel.Location;
            orderModel.Status = resultModel.Status;
            //---------------------------------------------
            orderModel.ClientName = resultModel.ClientName;
            orderModel.StoreName = resultModel.StoreName;
            orderModel.EmployeeName = resultModel.EmployeeName;

            return View(orderModel);
        }

        [HttpPost]
        public ActionResult Update(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateOrder(model.ClientId, model.StoreId, model.EmployeeId, model.OrderTime, 
                            model.OrderType, model.OrderSpecifications, model.Description, model.Location,
                            model.Status, model.ClientName, model.StoreName, model.EmployeeName);
            }
            return RedirectToAction("OrderList");
        }


        [HttpGet]
        public ActionResult UpdateLine(int id)
        {
            var resultModel = LoadOneLine(id);
            OrderLineModel orderModel = new OrderLineModel();

            orderModel.OrderLineId = resultModel.OrderLineId;
            orderModel.OrderId = resultModel.OrderId;
            orderModel.PartId = resultModel.PartId;
            orderModel.ServiceId = resultModel.ServiceId;
            orderModel.LineNo = resultModel.LineNo;
            orderModel.LineDescription = resultModel.LineDescription;
            orderModel.ServiceQty = resultModel.ServiceQty;
            orderModel.PartQty = resultModel.PartQty;
            orderModel.Status = resultModel.Status;
            orderModel.OrderNotes = resultModel.OrderNotes;
            orderModel.PartName = resultModel.PartName;
            orderModel.ServiceName = resultModel.ServiceName;
            //---------------------------------------------

            return View(orderModel);
        }

        [HttpPost]
        public ActionResult UpdateLine(OrderLineModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateOneOrderLine(model.OrderLineId, model.OrderId, model.PartId, model.ServiceId, model.LineNo, model.LineDescription,
                                                model.ServiceQty, model.PartQty, model.Status, model.OrderNotes, model.PartName, model.ServiceName);
            }
            return RedirectToAction("OrderList");
        }


        public ActionResult DeleteOrderByID(int Id)
        {
            DeleteOrder(Id);
            return RedirectToAction("OrderList");
        }

    }
}