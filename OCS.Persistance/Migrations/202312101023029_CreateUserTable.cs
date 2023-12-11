namespace OCS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSignUps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Cookies = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSignUps");
        }
    }
}
