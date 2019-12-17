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
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FeeNum = c.Int(),
                        Transgression = c.String(),
                        Remarks = c.String(),
                        LicensePlate = c.String(),
                        DriversFirstName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Appeal = c.String(),
                        GuardNumber = c.String(),
                        Amount = c.String(),
                        PaymentInfo = c.String(),
                        Zipcode = c.String(maxLength: 128),
                        CustomerEmail = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerEmail)
                .ForeignKey("dbo.ZipCities", t => t.Zipcode)
                .Index(t => t.Zipcode)
                .Index(t => t.CustomerEmail);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ZipCities",
                c => new
                    {
                        Zipcode = c.String(nullable: false, maxLength: 128),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Zipcode);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        AdditionalInfo = c.String(),
                        CustomerEmail = c.String(maxLength: 128),
                        EmployeeID = c.Int(),
                        ReplyID = c.Int(),
                        ClaimID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Claims", t => t.ClaimID)
                .ForeignKey("dbo.Customers", t => t.CustomerEmail)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .ForeignKey("dbo.Replies", t => t.ReplyID)
                .Index(t => t.CustomerEmail)
                .Index(t => t.EmployeeID)
                .Index(t => t.ReplyID)
                .Index(t => t.ClaimID);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReplyText = c.String(),
                        EmployeeID = c.Int(),
                        ClaimID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Claims", t => t.ClaimID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .Index(t => t.EmployeeID)
                .Index(t => t.ClaimID);
            
            CreateTable(
                "dbo.EmployeeClaims",
                c => new
                    {
                        Employee_ID = c.Int(nullable: false),
                        Claim_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_ID, t.Claim_ID })
                .ForeignKey("dbo.Employees", t => t.Employee_ID, cascadeDelete: true)
                .ForeignKey("dbo.Claims", t => t.Claim_ID, cascadeDelete: true)
                .Index(t => t.Employee_ID)
                .Index(t => t.Claim_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "ReplyID", "dbo.Replies");
            DropForeignKey("dbo.Replies", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Replies", "ClaimID", "dbo.Claims");
            DropForeignKey("dbo.Logs", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Logs", "CustomerEmail", "dbo.Customers");
            DropForeignKey("dbo.Logs", "ClaimID", "dbo.Claims");
            DropForeignKey("dbo.Claims", "Zipcode", "dbo.ZipCities");
            DropForeignKey("dbo.EmployeeClaims", "Claim_ID", "dbo.Claims");
            DropForeignKey("dbo.EmployeeClaims", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.Claims", "CustomerEmail", "dbo.Customers");
            DropIndex("dbo.EmployeeClaims", new[] { "Claim_ID" });
            DropIndex("dbo.EmployeeClaims", new[] { "Employee_ID" });
            DropIndex("dbo.Replies", new[] { "ClaimID" });
            DropIndex("dbo.Replies", new[] { "EmployeeID" });
            DropIndex("dbo.Logs", new[] { "ClaimID" });
            DropIndex("dbo.Logs", new[] { "ReplyID" });
            DropIndex("dbo.Logs", new[] { "EmployeeID" });
            DropIndex("dbo.Logs", new[] { "CustomerEmail" });
            DropIndex("dbo.Claims", new[] { "CustomerEmail" });
            DropIndex("dbo.Claims", new[] { "Zipcode" });
            DropTable("dbo.EmployeeClaims");
            DropTable("dbo.Replies");
            DropTable("dbo.Logs");
            DropTable("dbo.ZipCities");
            DropTable("dbo.Employees");
            DropTable("dbo.Claims");
            DropTable("dbo.Customers");
        }
    }
}
