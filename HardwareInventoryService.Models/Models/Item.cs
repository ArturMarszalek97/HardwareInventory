using HardwareInventoryService.Models.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Models
{
    public class Item
    {
        public int ItemID { get; set; }

        public int UserID { get; set; }

        public string ItemName { get; set; }

        public float Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string Shop { get; set; }

        public string Category { get; set; }

        public string Note { get; set; }

        public int Warranty { get; set; }
    }
}
