namespace Logger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "PhotoTime", c => c.DateTime());
            DropColumn("dbo.Photos", "PhotoDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "PhotoDate", c => c.DateTime());
            DropColumn("dbo.Photos", "PhotoTime");
        }
    }
}
