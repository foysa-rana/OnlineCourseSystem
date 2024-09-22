namespace OCS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateVideosTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Video = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "CourseId", "dbo.Courses");
            DropIndex("dbo.Videos", new[] { "CourseId" });
            DropTable("dbo.Videos");
        }
    }
}
