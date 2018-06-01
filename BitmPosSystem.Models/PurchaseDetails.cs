using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
   public class PurchaseDetails
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public double CostPrice { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public Purchase Purchase { get; set; }
    }
}
