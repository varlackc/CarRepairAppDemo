using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Order2Model
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderType { get; set; }
        public string Specifications { get; set; }
        public int EmployeeId { get; set; }
        public string OrderSpecifications { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int OrderLineId { get; set; }
        public int PartId { get; set; }
        public int ServiceId { get; set; }
        public int LineNo { get; set; }
        public string LineDescription { get; set; }
        public int ServiceQty { get; set; }
        public int PartQty { get; set;  }
        public string OrderNotes { get; set; }

    }
}
