namespace OCS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        Name = c.String(nullable: false),
                        Fee = c.String(nullable: false),
                        TrainerId = c.Int(nullable: false),
                        Duration = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.TrainerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "TrainerId" });
            DropTable("dbo.Courses");
        }
    }
}
