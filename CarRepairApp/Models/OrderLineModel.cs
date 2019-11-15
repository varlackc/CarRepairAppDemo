using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRepairApp.Models
{
    public class OrderLineModel
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public int PartId { get; set; }
        public int ServiceId { get; set; }
        public int LineNo { get; set; }
        public string LineDescription { get; set; }
        public int ServiceQty { get; set; }
        public int PartQty { get; set; }
        public string Status { get; set; }
        public string OrderNotes { get; set; }
    }
}