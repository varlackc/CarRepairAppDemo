using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    class OrderModel
    {
        int ClientId { get; set; }
        int StoreId { get; set; }
        int EmployeeId { get; set; }
        DateTime OrderTime { get; set; }
        string OrderType { get; set; }
        string OrderSpecifications { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        string Status { get; set; }
    }
}