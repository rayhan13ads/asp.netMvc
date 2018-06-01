using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
    public class ExpenseDetails
    {
        public int Id { get; set; }
        public int ExpenseItemId { get; set; }
        public int Qty { get; set; }
        public ExpenseItem ExpenseItem { get; set; }
        public Expense Expense { get; set; }
    }
}
