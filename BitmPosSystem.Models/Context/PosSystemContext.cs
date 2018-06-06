using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models.Context
{
    public class PosSystemContext:DbContext
    {


        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<Expense> Expenses  { get; set; }
        public DbSet<ExpenseDetails> ExpenseDetailses  { get; set; }
        public DbSet<Purchase> PurchaseTable { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetailses { get; set; }
        public DbSet<Sales> Saleses { get; set; }
        public DbSet<SalesDetails> SalesDetailses { get; set; }
        public DbSet<Organization> Organisetions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


    }
}
