using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRepairApp.Models;
using static DataLibrary.BusinessLogic.StoreProcessor;


namespace CarRepairApp.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult StoreList()
        {
            var data = LoadStore(); //load the data
            List<StoreModel> users = new List<StoreModel>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
            {
                users.Add(new StoreModel
                {
                    StoreId = row.StoreId,
                    StoreName = row.StoreName,
                    StoreAddress = row.StoreAddress,
                    PhoneNumber = row.PhoneNumber,
                    HoursOfOperation = row.HoursOfOperation
                });
            }
            return View(users);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Store";
            return View();
        }

        [HttpPost]
        public ActionResult Create(StoreModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateStore(model.StoreId, model.StoreName, model.StoreAddress, model.PhoneNumber,
                                                    model.HoursOfOperation);
                return RedirectToAction("StoreList");
            }
            ViewBag.Message = "Store List";
            return View();
        }

        public ActionResult DeleteStoreByID(int Id)
        {
            DeleteStore(Id);
            return RedirectToAction("StoreList");
        }

    }
}