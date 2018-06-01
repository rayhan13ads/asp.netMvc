namespace BitmPosSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intializdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        BranchCode = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        OrganisetionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisetions", t => t.OrganisetionId)
                .Index(t => t.OrganisetionId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmployeeCode = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        ContactNumber = c.String(),
                        EmengancyContactNumber = c.String(),
                        Email = c.String(),
                        NID = c.Int(nullable: false),
                        PrmanentAddress = c.String(),
                        PresentAddress = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        Referance = c.String(),
                        Image = c.Binary(),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseeDue = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        ExpenseDate = c.DateTime(nullable: false),
                        Reson = c.String(),
                        BranchId = c.Int(nullable: false),
                        ExpenseItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.ExpenseItems", t => t.ExpenseItem_Id)
                .Index(t => t.BranchId)
                .Index(t => t.ExpenseItem_Id);
            
            CreateTable(
                "dbo.ExpenseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseItemId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Expense_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expenses", t => t.Expense_Id)
                .ForeignKey("dbo.ExpenseItems", t => t.ExpenseItemId)
                .Index(t => t.ExpenseItemId)
                .Index(t => t.Expense_Id);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseItemName = c.String(),
                        ExpenseItemCode = c.String(),
                        Description = c.String(),
                        ExpenseCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseCategoryId)
                .Index(t => t.ExpenseCategoryId);
            
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ExpanseCode = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        ExpenseRootCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseRootCategoryId)
                .Index(t => t.ExpenseRootCategoryId);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        SalesId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        IncomeDate = c.DateTime(nullable: false),
                        IncomeAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId)
                .ForeignKey("dbo.Sales", t => t.SalesId)
                .Index(t => t.PurchaseId)
                .Index(t => t.SalesId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalAmount = c.Double(nullable: false),
                        PurchaseDue = c.Double(nullable: false),
                        PurchasseDate = c.DateTime(nullable: false),
                        Remark = c.String(),
                        BranchId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.BranchId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qty = c.Int(nullable: false),
                        CostPrice = c.Double(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Purchase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .Index(t => t.ItemId)
                .Index(t => t.Purchase_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemCode = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        CategoryId = c.Int(nullable: false),
                        CostPrice = c.Double(nullable: false),
                        SalePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CateogryCode = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        RootCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.RootCategoryId)
                .Index(t => t.RootCategoryId);
            
            CreateTable(
                "dbo.SalesDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Sales_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Sales", t => t.Sales_Id)
                .Index(t => t.ItemId)
                .Index(t => t.Sales_Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerCode = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vat = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        SaleDue = c.Double(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        BranchId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.BranchId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerCode = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organisetions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganisetionName = c.String(),
                        OrganisetionCode = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "OrganisetionId", "dbo.Organisetions");
            DropForeignKey("dbo.SalesDetails", "Sales_Id", "dbo.Sales");
            DropForeignKey("dbo.Incomes", "SalesId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sales", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.SalesDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.PurchaseDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "RootCategoryId", "dbo.Categories");
            DropForeignKey("dbo.Incomes", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Incomes", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.ExpenseDetails", "ExpenseItemId", "dbo.ExpenseItems");
            DropForeignKey("dbo.Expenses", "ExpenseItem_Id", "dbo.ExpenseItems");
            DropForeignKey("dbo.ExpenseItems", "ExpenseCategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.ExpenseCategories", "ExpenseRootCategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.ExpenseDetails", "Expense_Id", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Sales", new[] { "BranchId" });
            DropIndex("dbo.SalesDetails", new[] { "Sales_Id" });
            DropIndex("dbo.SalesDetails", new[] { "ItemId" });
            DropIndex("dbo.Categories", new[] { "RootCategoryId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.PurchaseDetails", new[] { "Purchase_Id" });
            DropIndex("dbo.PurchaseDetails", new[] { "ItemId" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.Purchases", new[] { "BranchId" });
            DropIndex("dbo.Incomes", new[] { "BranchId" });
            DropIndex("dbo.Incomes", new[] { "SalesId" });
            DropIndex("dbo.Incomes", new[] { "PurchaseId" });
            DropIndex("dbo.ExpenseCategories", new[] { "ExpenseRootCategoryId" });
            DropIndex("dbo.ExpenseItems", new[] { "ExpenseCategoryId" });
            DropIndex("dbo.ExpenseDetails", new[] { "Expense_Id" });
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseItemId" });
            DropIndex("dbo.Expenses", new[] { "ExpenseItem_Id" });
            DropIndex("dbo.Expenses", new[] { "BranchId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.Branches", new[] { "OrganisetionId" });
            DropTable("dbo.Organisetions");
            DropTable("dbo.Customers");
            DropTable("dbo.Sales");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SalesDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Purchases");
            DropTable("dbo.Incomes");
            DropTable("dbo.ExpenseCategories");
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.ExpenseDetails");
            DropTable("dbo.Expenses");
            DropTable("dbo.Employees");
            DropTable("dbo.Branches");
        }
    }
}
