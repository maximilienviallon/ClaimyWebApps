namespace ClaimyWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedEmailFromClaim : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Claims", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Claims", "Email", c => c.String());
        }
    }
}
