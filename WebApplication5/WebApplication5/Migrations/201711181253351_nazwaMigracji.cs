namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nazwaMigracji : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ZakupModels", "CzasModyfikacji", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ZakupModels", "CzasModyfikacji");
        }
    }
}
