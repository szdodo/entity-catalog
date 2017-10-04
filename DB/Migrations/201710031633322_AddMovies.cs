namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Actors", "Dvd_DvdId", "dbo.Dvds");
            DropIndex("dbo.Actors", new[] { "Dvd_DvdId" });
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Director = c.String(),
                        Genre = c.String(),
                        Dvd = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            AddColumn("dbo.Actors", "Movie_MovieId", c => c.Int());
            CreateIndex("dbo.Actors", "Movie_MovieId");
            AddForeignKey("dbo.Actors", "Movie_MovieId", "dbo.Movies", "MovieId");
            DropColumn("dbo.Actors", "Dvd_DvdId");
            DropTable("dbo.Dvds");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Actors", "Dvd_DvdId", c => c.Int());
            DropForeignKey("dbo.Actors", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.Actors", new[] { "Movie_MovieId" });
            DropColumn("dbo.Actors", "Movie_MovieId");
            DropTable("dbo.Movies");
            CreateIndex("dbo.Actors", "Dvd_DvdId");
            AddForeignKey("dbo.Actors", "Dvd_DvdId", "dbo.Dvds", "DvdId");
        }
    }
}
