using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    class ServiceModel
    {
        int ServiceId { get; set; }
        string ServiceName { get; set; }
        string ServiceDescription { get; set; }
        DateTime ServiceDate { get; set; }
        string Status { get; set; }
    }
}