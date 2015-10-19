namespace Logger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels : DbMigration
    {
        public override void Up()
        {/*
            CreateTable(
                "dbo.EntryTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryId = c.Int(nullable: false),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            */
        }
        
        public override void Down()
        {
            /*
            DropTable("dbo.Photos");
            DropTable("dbo.EntryTags");
             * */
        }
    }
}
