using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRepairApp.Models
{
    public class PartModel
    {
        int PartId { get; set; }
        string PartName { get; set; }
        string PartDescription { get; set; }
        string PartNumber { get; set; }
        string PartSupplier { get; set; }
        decimal PartCost { get; set; }
        decimal PartPrice { get; set; } 
    }
}