using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRepairApp.Models
{
    public class ClientModel
    {
        int ClientId { get; set; }
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Location { get; set; }
        string PhoneNumber { get; set; }
        string Status { get; set; }
    }
}