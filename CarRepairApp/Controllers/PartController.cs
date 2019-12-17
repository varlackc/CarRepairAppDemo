using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarRepairApp.Models;
using static DataLibrary.BusinessLogic.PartProcessor;


namespace CarRepairApp.Controllers
{
    public class PartController : Controller
    {
        public ActionResult PartList()
        {
            var data = LoadPart(); //load the data
            List<PartModel> users = new List<PartModel>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
            {
                users.Add(new PartModel
                {
                    PartId = row.PartId,
                    PartName = row.PartName,
                    PartNumber = row.PartNumber,
                    PartDescription = row.PartDescription,
                    PartCost = row.PartCost,
                    PartPrice = row.PartPrice,
                    PartSupplier = row.PartSupplier
                    
                });
            }
            return View(users);
        }


        public ActionResult Create()
        {
            ViewBag.Message = "Part";
            return View();
        }

        [HttpPost]
        public ActionResult Create(PartModel model)
        {
            if (ModelState.IsValid)
            { 
                //Note: When calling a method, the order of the parameters is very important
                int recordsCreated = CreatePart( model.PartId, model.PartName, model.PartDescription, 
                    model.PartNumber, model.PartSupplier, model.PartCost, model.PartPrice);

                return RedirectToAction("PartList");
            }
            ViewBag.Message = "Part List";
            return View();
        }


        public ActionResult Update(int id)
        {
            var resultModel = LoadOnePart(id); //get the results from the databaase
            PartModel partModel = new PartModel(); //convert the results in a way that the view can understand

            partModel.PartId = resultModel.PartId;
            partModel.PartName = resultModel.PartName;
            partModel.PartNumber = resultModel.PartNumber;
            partModel.PartDescription = resultModel.PartDescription;
            partModel.PartCost = resultModel.PartCost;
            partModel.PartPrice = resultModel.PartPrice;
            partModel.PartSupplier = resultModel.PartSupplier;

            return View(partModel);
        }

        [HttpPost]
        public ActionResult Update(PartModel model)
        {
            if (ModelState.IsValid)
            {
                UpdatePart(model.PartId, model.PartName, model.PartDescription,
                    model.PartNumber, model.PartSupplier, model.PartCost, model.PartPrice);
            }
            return RedirectToAction("PartList");
        }

        public ActionResult DeletePartByID(int Id)
        {
            DeletePart(Id);
            return RedirectToAction("PartList");
        }

    }
}