using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class PartModel
    {
        public int PartId { get; set; }
        public string PartName { get; set; }
        public string PartDescription { get; set; }
        public string PartNumber { get; set; }
        public string PartSupplier { get; set; }
        public decimal PartCost { get; set; }
        public decimal PartPrice { get; set; }
    }
}