using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarRepairApp.Models;
using static DataLibrary.BusinessLogic.OrderProcessor;

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
    }
}