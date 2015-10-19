namespace Logger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nanjing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "PhotoNanjing", c => c.Binary());
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "PhotoData", c => c.Binary());
            DropColumn("dbo.Photos", "PhotoNanjing");
        }
    }
}
