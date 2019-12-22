using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairApp.Models;

namespace CarRepairApp.Models
{
    public class OrderStructureModel
    {
        public OrderModel OrderHead { get; set; }
        public List<OrderLineModel> OrderBody { get; set; }
    }
}