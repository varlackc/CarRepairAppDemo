using System.Collections.Generic;
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

        public ActionResult SeviceDetails(int id)
        {
            var data = LoadOneService(id);
            ServiceModel serviceModel = new ServiceModel(); //convert the results in a way that the view can understand
            serviceModel.ServiceId = data.ServiceId;
            serviceModel.ServiceName = data.ServiceName;
            serviceModel.ServiceDescription = data.ServiceDescription;
            serviceModel.ServiceDate = data.ServiceDate;
            serviceModel.Status = data.Status;
            serviceModel.ServiceType = data.ServiceType;
            return View(serviceModel);

        }

        public ActionResult Create()
        {
            ViewBag.Message = "Service";
            return View();
        }

        [HttpPost]
        public ActionResult Create(ServiceModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateService(model.ServiceId, model.ServiceName, model.ServiceDescription, model.ServiceDate,
                                                    model.Status, model.ServiceType);
                return RedirectToAction("ServiceList");
            }
            ViewBag.Message = "Service List";
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var resultModel = LoadOneService(id); //get the results from the databaase
            ServiceModel serviceModel = new ServiceModel(); //convert the results in a way that the view can understand
            serviceModel.ServiceId = resultModel.ServiceId;
            serviceModel.ServiceName = resultModel.ServiceName;
            serviceModel.ServiceDescription = resultModel.ServiceDescription;
            serviceModel.ServiceDate = resultModel.ServiceDate;
            serviceModel.Status = resultModel.Status;
            serviceModel.ServiceType = resultModel.ServiceType;
            return View(serviceModel);
        }

        [HttpPost]
        public ActionResult Update(ServiceModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateService(model.ServiceId, model.ServiceName, model.ServiceDescription, model.ServiceDate,
                                                    model.Status, model.ServiceType);
            }
            return RedirectToAction("ServiceList");
        }

        public ActionResult DeleteServiceByID(int Id)
        {
            DeleteService(Id);
            return RedirectToAction("ServiceList");
        }

    }
}