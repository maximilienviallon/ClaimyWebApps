namespace ClaimyWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedEmailFromClaim : DbMigration
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
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
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Replies", new[] { "ClaimID" });
            DropIndex("dbo.Replies", new[] { "EmployeeID" });
            DropIndex("dbo.Logs", new[] { "ClaimID" });
            DropIndex("dbo.Logs", new[] { "ReplyID" });
            DropIndex("dbo.Logs", new[] { "EmployeeID" });
            DropIndex("dbo.Logs", new[] { "CustomerEmail" });
            DropIndex("dbo.Claims", new[] { "CustomerEmail" });
            DropIndex("dbo.Claims", new[] { "Zipcode" });
            DropTable("dbo.EmployeeClaims");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Replies");
            DropTable("dbo.Logs");
            DropTable("dbo.ZipCities");
            DropTable("dbo.Employees");
            DropTable("dbo.Claims");
            DropTable("dbo.Customers");
        }
    }
}
