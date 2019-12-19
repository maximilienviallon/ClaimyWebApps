namespace ClaimyWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertedEmailToCustomerEmail : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Claims", name: "Email", newName: "CustomerEmail");
            RenameIndex(table: "dbo.Claims", name: "IX_Email", newName: "IX_CustomerEmail");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Claims", name: "IX_CustomerEmail", newName: "IX_Email");
            RenameColumn(table: "dbo.Claims", name: "CustomerEmail", newName: "Email");
        }
    }
}
