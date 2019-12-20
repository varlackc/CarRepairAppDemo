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

        public ActionResult OrderDetails(int id)
        {
            //load the complete order
            var order = LoadOneOrder(id);
            var orderLineList = LoadOrderLine(id);

            OrderLineModel newOrderLine = new OrderLineModel();


            var FinalOrder = new OrderStructure
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

        /*
        [HttpGet]
        public ActionResult Create()
        {

        }

        [HttpPost]
        public ActionResult Create(OrderModel model)
        {

        }


        [HttpGet]
        public ActionResult Update(OrderModel model)
        {

        }

        [HttpPost]
        public ActionResult Update(OrderModel model)
        {

        }
        */

        public ActionResult DeleteOrderByID(int Id)
        {
            DeleteOrder(Id);
            return RedirectToAction("OrderList");
        }

    }
}