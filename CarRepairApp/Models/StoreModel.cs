using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRepairApp.Models
{
    public class StoreModel
    {
        int StoreId { get; set; }
        string StoreName { get; set; }
        string StoreAddress { get; set; }
        string PhoneNumber { get; set; }
        string HoursOfOperation { get; set; }
    }
}