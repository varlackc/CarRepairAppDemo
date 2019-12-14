using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataLibrary;
using CarRepairApp.Models;
using static DataLibrary.BusinessLogic.EmployeeProcessor;

namespace CarRepairApp.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult EmployeeList()
        {
            var data = LoadEmployee(); //load the data
            List<EmployeeModel> users = new List<EmployeeModel>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
            {
                users.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId, 
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