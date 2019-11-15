using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRepairApp.Models
{
    public class ServiceModel
    {
        int ServiceId { get; set; }
        string ServiceName { get; set; }
        string ServiceDescription { get; set; }
        DateTime ServiceDate { get; set; }
        string Status { get; set; }
    }
}