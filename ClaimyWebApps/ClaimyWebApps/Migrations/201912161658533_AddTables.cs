namespace ClaimyWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimID = c.Int(nullable: false, identity: true),
                        FeeNum = c.Int(nullable: false),
                        Transgression = c.String(),
                        Remarks = c.String(),
                        LicensePlate = c.String(),
                        DriversFirstName = c.String(),
                        Address = c.String(),
                        PostCode = c.String(),
                        Email = c.String(),
                        Appeal = c.String(),
                        GuardNumber = c.String(),
                        Amount = c.String(),
                        PaymentInfo = c.String(),
                        Log_LogID = c.Int(),
                        Reply_ReplyID = c.Int(),
                    })
                .PrimaryKey(t => t.ClaimID)
                .ForeignKey("dbo.Logs", t => t.Log_LogID)
                .ForeignKey("dbo.Replies", t => t.Reply_ReplyID)
                .Index(t => t.Log_LogID)
                .Index(t => t.Reply_ReplyID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        AdditionalInfo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogID);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyID = c.Int(nullable: false, identity: true),
                        ReplyText = c.String(),
                        Customer_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.ReplyID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.ZipCities",
                c => new
                    {
                        Zipcode = c.String(nullable: false, maxLength: 128),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Zipcode);
            
            CreateTable(
                "dbo.ClaimCustomers",
                c => new
                    {
                        Claim_ClaimID = c.Int(nullable: false),
                        Customer_CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Claim_ClaimID, t.Customer_CustomerID })
                .ForeignKey("dbo.Claims", t => t.Claim_ClaimID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .Index(t => t.Claim_ClaimID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.EmployeeClaims",
                c => new
                    {
                        Employee_EmployeeID = c.Int(nullable: false),
                        Claim_ClaimID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeID, t.Claim_ClaimID })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Claims", t => t.Claim_ClaimID, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.Claim_ClaimID);
            
            CreateTable(
                "dbo.LogCustomers",
                c => new
                    {
                        Log_LogID = c.Int(nullable: false),
                        Customer_CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Log_LogID, t.Customer_CustomerID })
                .ForeignKey("dbo.Logs", t => t.Log_LogID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .Index(t => t.Log_LogID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.LogEmployees",
                c => new
                    {
                        Log_LogID = c.Int(nullable: false),
                        Employee_EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Log_LogID, t.Employee_EmployeeID })
                .ForeignKey("dbo.Logs", t => t.Log_LogID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID, cascadeDelete: true)
                .Index(t => t.Log_LogID)
                .Index(t => t.Employee_EmployeeID);
            
            CreateTable(
                "dbo.ReplyEmployees",
                c => new
                    {
                        Reply_ReplyID = c.Int(nullable: false),
                        Employee_EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reply_ReplyID, t.Employee_EmployeeID })
                .ForeignKey("dbo.Replies", t => t.Reply_ReplyID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID, cascadeDelete: true)
                .Index(t => t.Reply_ReplyID)
                .Index(t => t.Employee_EmployeeID);
            
            CreateTable(
                "dbo.ReplyLogs",
                c => new
                    {
                        Reply_ReplyID = c.Int(nullable: false),
                        Log_LogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reply_ReplyID, t.Log_LogID })
                .ForeignKey("dbo.Replies", t => t.Reply_ReplyID, cascadeDelete: true)
                .ForeignKey("dbo.Logs", t => t.Log_LogID, cascadeDelete: true)
                .Index(t => t.Reply_ReplyID)
                .Index(t => t.Log_LogID);
            
            CreateTable(
                "dbo.ZipCityClaims",
                c => new
                    {
                        ZipCity_Zipcode = c.String(nullable: false, maxLength: 128),
                        Claim_ClaimID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ZipCity_Zipcode, t.Claim_ClaimID })
                .ForeignKey("dbo.ZipCities", t => t.ZipCity_Zipcode, cascadeDelete: true)
                .ForeignKey("dbo.Claims", t => t.Claim_ClaimID, cascadeDelete: true)
                .Index(t => t.ZipCity_Zipcode)
                .Index(t => t.Claim_ClaimID);
            
            CreateTable(
                "dbo.ZipCityCustomers",
                c => new
                    {
                        ZipCity_Zipcode = c.String(nullable: false, maxLength: 128),
                        Customer_CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ZipCity_Zipcode, t.Customer_CustomerID })
                .ForeignKey("dbo.ZipCities", t => t.ZipCity_Zipcode, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .Index(t => t.ZipCity_Zipcode)
                .Index(t => t.Customer_CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.ZipCityCustomers", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.ZipCityCustomers", "ZipCity_Zipcode", "dbo.ZipCities");
            DropForeignKey("dbo.ZipCityClaims", "Claim_ClaimID", "dbo.Claims");
            DropForeignKey("dbo.ZipCityClaims", "ZipCity_Zipcode", "dbo.ZipCities");
            DropForeignKey("dbo.ReplyLogs", "Log_LogID", "dbo.Logs");
            DropForeignKey("dbo.ReplyLogs", "Reply_ReplyID", "dbo.Replies");
            DropForeignKey("dbo.ReplyEmployees", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.ReplyEmployees", "Reply_ReplyID", "dbo.Replies");
            DropForeignKey("dbo.Claims", "Reply_ReplyID", "dbo.Replies");
            DropForeignKey("dbo.LogEmployees", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.LogEmployees", "Log_LogID", "dbo.Logs");
            DropForeignKey("dbo.LogCustomers", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.LogCustomers", "Log_LogID", "dbo.Logs");
            DropForeignKey("dbo.Claims", "Log_LogID", "dbo.Logs");
            DropForeignKey("dbo.EmployeeClaims", "Claim_ClaimID", "dbo.Claims");
            DropForeignKey("dbo.EmployeeClaims", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.ClaimCustomers", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.ClaimCustomers", "Claim_ClaimID", "dbo.Claims");
            DropIndex("dbo.ZipCityCustomers", new[] { "Customer_CustomerID" });
            DropIndex("dbo.ZipCityCustomers", new[] { "ZipCity_Zipcode" });
            DropIndex("dbo.ZipCityClaims", new[] { "Claim_ClaimID" });
            DropIndex("dbo.ZipCityClaims", new[] { "ZipCity_Zipcode" });
            DropIndex("dbo.ReplyLogs", new[] { "Log_LogID" });
            DropIndex("dbo.ReplyLogs", new[] { "Reply_ReplyID" });
            DropIndex("dbo.ReplyEmployees", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.ReplyEmployees", new[] { "Reply_ReplyID" });
            DropIndex("dbo.LogEmployees", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.LogEmployees", new[] { "Log_LogID" });
            DropIndex("dbo.LogCustomers", new[] { "Customer_CustomerID" });
            DropIndex("dbo.LogCustomers", new[] { "Log_LogID" });
            DropIndex("dbo.EmployeeClaims", new[] { "Claim_ClaimID" });
            DropIndex("dbo.EmployeeClaims", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.ClaimCustomers", new[] { "Customer_CustomerID" });
            DropIndex("dbo.ClaimCustomers", new[] { "Claim_ClaimID" });
            DropIndex("dbo.Replies", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Claims", new[] { "Reply_ReplyID" });
            DropIndex("dbo.Claims", new[] { "Log_LogID" });
            DropTable("dbo.ZipCityCustomers");
            DropTable("dbo.ZipCityClaims");
            DropTable("dbo.ReplyLogs");
            DropTable("dbo.ReplyEmployees");
            DropTable("dbo.LogEmployees");
            DropTable("dbo.LogCustomers");
            DropTable("dbo.EmployeeClaims");
            DropTable("dbo.ClaimCustomers");
            DropTable("dbo.ZipCities");
            DropTable("dbo.Replies");
            DropTable("dbo.Logs");
            DropTable("dbo.Employees");
            DropTable("dbo.Claims");
            DropTable("dbo.Customers");
        }
    }
}
