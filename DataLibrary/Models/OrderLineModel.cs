using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class OrderLineModel
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public int? PartId { get; set; }
        public int? ServiceId { get; set; }
        public int LineNo { get; set; }
        public string LineDescription { get; set; }
        public int? ServiceQty { get; set; }
        public int? PartQty { get; set; }
        public string Status { get; set; }
        public string OrderNotes { get; set; }
        public string PartName { get; set; }
        public string ServiceName { get; set; }
    }
}