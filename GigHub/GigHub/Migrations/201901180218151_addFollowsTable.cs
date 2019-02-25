namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFollowsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowerId = c.Int(nullable: false),
                        FollowedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FollowedId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Follows");
        }
    }
}
