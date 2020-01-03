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

        public ActionResult EmployeeDetails(int id)
        {
            var data = LoadOneEmployee(id);
            EmployeeModel employeeModel = new EmployeeModel(); //convert the results in a way that the view can understand
            employeeModel.EmployeeId = data.EmployeeId;
            employeeModel.UserName = data.UserName;
            employeeModel.FirstName = data.FirstName;
            employeeModel.LastName = data.LastName;
            employeeModel.Location = data.Location;
            employeeModel.PhoneNumber = data.PhoneNumber;
            employeeModel.Status = data.Status;
            return View(employeeModel);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Employee";
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateEmployee(model.EmployeeId, model.UserName, model.FirstName, model.LastName, 
                                                    model.Location, model.PhoneNumber, model.Status);
                return RedirectToAction("EmployeeList");
            }
            ViewBag.Message = "Employee List";
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var resultModel = LoadOneEmployee(id); //get the results from the databaase
            EmployeeModel employeeModel = new EmployeeModel(); //convert the results in a way that the view can understand
            employeeModel.EmployeeId = resultModel.EmployeeId;
            employeeModel.UserName = resultModel.UserName;
            employeeModel.FirstName = resultModel.FirstName;
            employeeModel.LastName = resultModel.LastName;
            employeeModel.Location = resultModel.Location;
            employeeModel.PhoneNumber = resultModel.PhoneNumber;
            employeeModel.Status = resultModel.Status;
            return View(employeeModel);
        }

        [HttpPost]
        public ActionResult Update(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateEmployee(model.EmployeeId, model.UserName, model.FirstName, model.LastName, 
                    model.Location, model.PhoneNumber, model.Status);
            }
            return RedirectToAction("EmployeeList");
        }

        public ActionResult DeleteEmployeeByID(int Id)
        {
            DeleteEmployee(Id);
            return RedirectToAction("EmployeeList");
        }

    }
}