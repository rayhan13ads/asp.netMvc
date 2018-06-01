using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
   public class Expense
    {
        public int Id { get; set; }
        public double ExpenseeDue { get; set; }
        public double TotalAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Reson { get; set; }
        public int BranchId { get; set; }
        public ICollection<ExpenseDetails> ExpenseDetailses { get; set; }
        public Branch Branch { get; set; }
    }
}
