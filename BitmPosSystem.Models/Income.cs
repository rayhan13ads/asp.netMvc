using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
   public class Income
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int SalesId  { get; set; }
        public int BranchId { get; set; }
        public DateTime IncomeDate { get; set; }
        public double IncomeAmount { get; set; }
        public Purchase Purchase { get; set; }
        public Branch Branch { get; set; }
        public Sales Sales { get; set; }
    }
}
