using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
   public class ExpenseItem
    {
        public int Id { get; set; }
        public string ExpenseItemName { get; set; }
        public string ExpenseItemCode { get; set; }
        public string Description { get; set; }
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
