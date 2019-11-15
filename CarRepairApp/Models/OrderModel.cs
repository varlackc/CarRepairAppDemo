using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRepairApp.Models
{
    public class OrderModel
    {
        public int ClientId { get; set; }
        public int StoreId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderType { get; set; }
        public string OrderSpecifications { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}