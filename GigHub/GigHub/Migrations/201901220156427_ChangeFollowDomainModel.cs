namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFollowDomainModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 100));
            CreateIndex("dbo.Follows", "FollowerId");
            CreateIndex("dbo.Follows", "FollowedId");
            AddForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Follows", "FollowedId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FollowedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "FollowedId" });
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
