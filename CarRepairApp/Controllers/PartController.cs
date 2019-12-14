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
    }
}