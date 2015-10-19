namespace Logger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "PhotoData", c => c.Binary());
            DropColumn("dbo.Photos", "PhotoNanjing");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "PhotoNanjing", c => c.Binary());
            DropColumn("dbo.Photos", "PhotoData");
        }
    }
}
