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
                        TrainerId = c.String(),
                        Photo = c.String(),
                        FName = c.String(),
                        Lname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        JobTitle = c.String(),
                        Position = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trainers");
        }
    }
}
