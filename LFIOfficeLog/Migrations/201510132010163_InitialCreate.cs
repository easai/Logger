namespace Logger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            /*
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogDate = c.DateTime(),
                        LogText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            */
        }
        
        public override void Down()
        {
          //  DropTable("dbo.Entries");
        }
    }
}
