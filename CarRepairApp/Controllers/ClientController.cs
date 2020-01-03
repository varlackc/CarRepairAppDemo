using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CarRepairApp.Models;
using static DataLibrary.BusinessLogic.ClientProcessor;

namespace CarRepairApp.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult ClientList()
        {
            var data = LoadClient(); //load the data
            List<ClientModel> users = new List<ClientModel>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
            {
                users.Add(new ClientModel
                {
                    ClientId = row.ClientId,
                    UserName = row.UserName,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Location = row.Location,
                    PhoneNumber = row.PhoneNumber,
                    Status = row.Status
                });
            }
            return View(users);
        }

        public ActionResult ClientDetails(int id)
        {
            var data = LoadOneClient(id);
            ClientModel clientModel = new ClientModel(); //convert the results in a way that the view can understand
            clientModel.ClientId = data.ClientId;
            clientModel.UserName = data.UserName;
            clientModel.FirstName = data.FirstName;
            clientModel.LastName = data.LastName;
            clientModel.Location = data.Location;
            clientModel.PhoneNumber = data.PhoneNumber;
            clientModel.Status = data.Status;

            return View(clientModel);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Client";
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateClient(model.ClientId, model.UserName, model.FirstName, 
                    model.LastName, model.Location, model.PhoneNumber, model.Status);

                return RedirectToAction("ClientList");
            }
            ViewBag.Message = "Client List";
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var data = LoadOneClient(id); //get the results from the databaase
            ClientModel clientModel = new ClientModel(); //convert the results in a way that the view can understand
            clientModel.ClientId = data.ClientId;
            clientModel.UserName = data.UserName;
            clientModel.FirstName = data.FirstName;
            clientModel.LastName = data.LastName;
            clientModel.Location = data.Location;
            clientModel.PhoneNumber = data.PhoneNumber;
            clientModel.Status = data.Status;

            return View(clientModel);
        }

        [HttpPost]
        public ActionResult Update(ClientModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateClient(model.ClientId, model.UserName, model.FirstName,
                    model.LastName, model.Location, model.PhoneNumber, model.Status);
            }
            return RedirectToAction("ClientList");
        }

        public ActionResult DeleteClientByID(int Id)
        {
            DeleteClient(Id);
            return RedirectToAction("ClientList");
        }

    }
}