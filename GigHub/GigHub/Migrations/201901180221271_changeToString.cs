namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeToString : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Follows");
            AlterColumn("dbo.Follows", "FollowerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Follows", "FollowedId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Follows", new[] { "FollowerId", "FollowedId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Follows");
            AlterColumn("dbo.Follows", "FollowerId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Follows", new[] { "FollowerId", "FollowedId" });
        }
    }
}
