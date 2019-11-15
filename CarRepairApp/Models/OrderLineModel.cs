using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRepairApp.Models
{
    public class OrderLineModel
    {
        int OrderLineId { get; set; }
        int OrderId { get; set; }
        int PartId { get; set; }
        int ServiceId { get; set; }
        int LineNo { get; set; }
        string LineDescription { get; set; }
        int ServiceQty { get; set; }
        int PartQty { get; set; }
        string Status { get; set; }
        string OrderNotes { get; set; }
    }
}