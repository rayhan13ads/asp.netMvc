using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public double CostPrice { get; set; }
        public double TotalAmount { get; set; }
        public double PurchaseDue { get; set; }
        public DateTime PurchasseDate { get; set; }
        public string Remark { get; set; }
        public int ItemId { get; set; }
        public int BranchId { get; set; }
        public int SupplierId { get; set; }
        public Item Item { get; set; }
        public Branch Branch { get; set; }
        public Supplier Supplier { get; set; }
        public List<Income> Incomes { get; set; }
    }
}
