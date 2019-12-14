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
        public ActionResult OrderList(int id)
        {
            var data = LoadOrder(id); //load the data
            List<OrderModel> users = new List<OrderModel>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
            {
                users.Add(new OrderModel
                {
                    OrderType = row.OrderType,
                    OrderSpecifications = row.OrderSpecifications,
                    OrderTime = row.OrderTime

                });
            }
            return View(users);
        }
    }
}