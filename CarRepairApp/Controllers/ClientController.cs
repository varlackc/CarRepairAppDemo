using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;

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
                    PhoneNumber = row.Location,
                    Status = row.Status
                });
            }
            return View(users);
        }
    }
}