using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarRepairApp.Models;
using static DataLibrary.BusinessLogic.ServiceProcessor;

namespace CarRepairApp.Controllers
{
    public class ServiceController : Controller
    {  
        public ActionResult ServiceList()
        {
            var data = LoadService(); //load the data
            List<ServiceModel> users = new List<ServiceModel>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
            {
                users.Add(new ServiceModel
                {
                    ServiceId = row.ServiceId,
                    ServiceName = row.ServiceName,
                    ServiceDescription = row.ServiceDescription,
                    ServiceDate = row.ServiceDate,
                    Status = row.Status, 
                    ServiceType = row.ServiceType
                });
            }
            return View(users);
        }
    }
}