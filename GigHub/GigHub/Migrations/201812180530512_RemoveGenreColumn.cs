namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGenreColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Gigs", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
