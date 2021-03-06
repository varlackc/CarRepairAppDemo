﻿using System.Collections.Generic;
using System.Web.Mvc;
using CarRepairApp.Models;
using static DataLibrary.BusinessLogic.StoreProcessor;


namespace CarRepairApp.Controllers
{
    public class StoreController : Controller
    {
        // Store List
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

        // Store Details
        public ActionResult StoreDetails(int id)
        {
            var data = LoadOneStore(id);
            StoreModel storeModel = new StoreModel(); //convert the results in a way that the view can understand
            storeModel.StoreId = data.StoreId;
            storeModel.StoreName = data.StoreName;
            storeModel.StoreAddress = data.StoreAddress;
            storeModel.PhoneNumber = data.PhoneNumber;
            storeModel.HoursOfOperation = data.HoursOfOperation;
            return View(storeModel);
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

        public ActionResult Update(int id)
        {
            var resultModel = LoadOneStore(id); //get the results from the databaase
            StoreModel storeModel = new StoreModel(); //convert the results in a way that the view can understand
            storeModel.StoreId = resultModel.StoreId;
            storeModel.StoreName = resultModel.StoreName;
            storeModel.StoreAddress = resultModel.StoreAddress;
            storeModel.PhoneNumber = resultModel.PhoneNumber;
            storeModel.HoursOfOperation = resultModel.HoursOfOperation;
            return View(storeModel);
        }

        [HttpPost]
        public ActionResult Update(StoreModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateStore(model.StoreId, model.StoreName, model.StoreAddress, model.PhoneNumber,
                    model.HoursOfOperation);
            }
            return RedirectToAction("StoreList");
        }


        public ActionResult DeleteStoreByID(int Id)
        {
            DeleteStore(Id);
            return RedirectToAction("StoreList");
        }

    }
}