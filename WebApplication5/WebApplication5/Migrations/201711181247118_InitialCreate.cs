namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ZakupModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Produkt = c.String(),
                        Cena = c.Int(nullable: false),
                        CzasDodania = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ZakupModels");
        }
    }
}
