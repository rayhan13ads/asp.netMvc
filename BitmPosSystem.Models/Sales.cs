using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
   public class Sales
    {
        public int Id { get; set; }
        public double Vat { get; set; }
        public double Discount { get; set; }
        public double SubTotal { get; set; }
        public double TotalAmount { get; set; }
        public double SaleDue { get; set; }
        public DateTime SaleDate { get; set; }
        public int BranchId { get; set; }
        public int CustomerId { get; set; }
        public ICollection<SalesDetails> SalesDetailses { get; set; }
        public Branch Branch { get; set; }
        public Customer Customer { get; set; }
        public List<Income> Incomes { get; set; }
    }
}
