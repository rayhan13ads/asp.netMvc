using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
   public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExpanseCode { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int ExpenseRootCategoryId { get; set; }
        public ExpenseCategory ExpenseRootCategory { get; set; }
        public List<ExpenseCategory> ExpenseChildCategories { get; set; }
        public List<ExpenseItem> Items { get; set; }
    }
}
