using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
   public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int CategoryId { get; set; }
        public Double CostPrice { get; set; }
        public Double SalePrice { get; set; }
        public Category Category { get; set; }
        public List<PurchaseDetails> Purchases { get; set; }
        public List<SalesDetails> Saleses { get; set; }

    }
}
