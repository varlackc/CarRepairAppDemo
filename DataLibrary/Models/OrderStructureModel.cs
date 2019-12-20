using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public class OrderStructure
    {
        public OrderModel OrderHeading { get; set; }
        public List<OrderLineModel> OrderBody { get; set; }
    }
}
