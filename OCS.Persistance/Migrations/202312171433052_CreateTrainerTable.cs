namespace OCS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTrainerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(nullable: false),
                        Photo = c.String(),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        JobTitle = c.String(nullable: false),
                        Position = c.String(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        PresentAddress = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                        About = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trainers");
        }
    }
}
