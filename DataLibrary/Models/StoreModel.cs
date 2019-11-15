using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    class StoreModel
    {
        int StoreId { get; set; }
        string StoreName { get; set; }
        string StoreAddress { get; set; }
        string PhoneNumber { get; set; }
        string HoursOfOperation { get; set; }
    }
}