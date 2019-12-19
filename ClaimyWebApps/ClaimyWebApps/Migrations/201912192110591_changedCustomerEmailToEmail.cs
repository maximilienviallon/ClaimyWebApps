namespace ClaimyWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedCustomerEmailToEmail : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Claims", name: "CustomerEmail", newName: "Email");
            RenameIndex(table: "dbo.Claims", name: "IX_CustomerEmail", newName: "IX_Email");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Claims", name: "IX_Email", newName: "IX_CustomerEmail");
            RenameColumn(table: "dbo.Claims", name: "Email", newName: "CustomerEmail");
        }
    }
}
