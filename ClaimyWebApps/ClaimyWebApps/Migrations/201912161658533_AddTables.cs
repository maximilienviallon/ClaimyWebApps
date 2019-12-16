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
                        Address = c.String(),
                        PostCode = c.String(),
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
                        DriversName = c.String(),
                        Address = c.String(),
                        PostCode = c.String(),
                        Email = c.String(),
                        Appeal = c.String(),
                        GuardNumber = c.String(),
                        Amount = c.String(),
                        PaymentInfo = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClaimID);
            
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
                        EmployeeID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        ClaimID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogID);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyID = c.Int(nullable: false, identity: true),
                        ReplyText = c.String(),
                        EmployeeID = c.Int(nullable: false),
                        ClaimID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Replies");
            DropTable("dbo.Logs");
            DropTable("dbo.Employees");
            DropTable("dbo.Claims");
            DropTable("dbo.Customers");
        }
    }
}
