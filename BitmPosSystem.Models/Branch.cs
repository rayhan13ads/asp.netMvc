using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
   public class Branch
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }

        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public int OrganisetionId { get; set; }
        public Organisetion Organisetion { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Sales> Saleses { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<Income> Incomes { get; set; }
    }
}
