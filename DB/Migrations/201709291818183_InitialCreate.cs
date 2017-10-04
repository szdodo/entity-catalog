namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        Dvd_DvdId = c.Int(),
                    })
                .PrimaryKey(t => t.ActorId)
                .ForeignKey("dbo.Dvds", t => t.Dvd_DvdId)
                .Index(t => t.Dvd_DvdId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Director = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.DvdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actors", "Dvd_DvdId", "dbo.Dvds");
            DropIndex("dbo.Actors", new[] { "Dvd_DvdId" });
            DropTable("dbo.Dvds");
            DropTable("dbo.Books");
            DropTable("dbo.Actors");
        }
    }
}
