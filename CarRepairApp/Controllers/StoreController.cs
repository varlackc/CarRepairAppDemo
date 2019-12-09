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
            var data = LoadUser(); //load the data
            List<UserModel> users = new List<UserModel>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
            {
                users.Add(new UserModel
                {
                    Id = row.Id,
                    UserName = row.UserName,
                    FirstName = row.FirstName,
                    LastName = row.LastName
                });
            }
            return View(users);
        }
    }
}