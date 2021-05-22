namespace MyAnime_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateDataAnnotations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "MyAnime.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "MyAnime.SerieCategory",
                c => new
                    {
                        SerieCategoryId = c.Int(nullable: false, identity: true),
                        SerieId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerieCategoryId)
                .ForeignKey("MyAnime.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("MyAnime.Serie", t => t.SerieId, cascadeDelete: true)
                .Index(t => t.SerieId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "MyAnime.Serie",
                c => new
                    {
                        SerieId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Discription = c.String(nullable: false),
                        Image = c.Binary(nullable: false, storeType: "image"),
                        AirDate = c.DateTime(nullable: false),
                        TypeId = c.Int(nullable: false),
                        ContentRatingId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.SerieId)
                .ForeignKey("MyAnime.ContentRating", t => t.ContentRatingId, cascadeDelete: true)
                .ForeignKey("MyAnime.Type", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("MyAnime.AppUser", t => t.User_UserId)
                .Index(t => t.TypeId)
                .Index(t => t.ContentRatingId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "MyAnime.ContentRating",
                c => new
                    {
                        ContentRatingId = c.Int(nullable: false, identity: true),
                        Image = c.Binary(nullable: false, storeType: "image"),
                        Rating = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ContentRatingId);
            
            CreateTable(
                "MyAnime.Episode",
                c => new
                    {
                        EpisodeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Image = c.Binary(nullable: false, storeType: "image"),
                        Number = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Season = c.Int(nullable: false),
                        SerieId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.EpisodeId)
                .ForeignKey("MyAnime.Serie", t => t.SerieId, cascadeDelete: true)
                .ForeignKey("MyAnime.AppUser", t => t.User_UserId)
                .Index(t => t.SerieId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "MyAnime.AppUser",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 255),
                        EmailAddress = c.String(nullable: false, maxLength: 450),
                        PasswordHash = c.String(nullable: false, maxLength: 450),
                        IsAdmin = c.Boolean(nullable: false),
                        Episodes_EpisodeId = c.Int(),
                        Series_SerieId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("MyAnime.Episode", t => t.Episodes_EpisodeId)
                .ForeignKey("MyAnime.Serie", t => t.Series_SerieId)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.EmailAddress, unique: true)
                .Index(t => t.Episodes_EpisodeId)
                .Index(t => t.Series_SerieId);
            
            CreateTable(
                "MyAnime.UserEpisode",
                c => new
                    {
                        UserEpisodeID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        EpisodeId = c.Int(nullable: false),
                        Watched = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserEpisodeID)
                .ForeignKey("MyAnime.Episode", t => t.EpisodeId, cascadeDelete: true)
                .ForeignKey("MyAnime.AppUser", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.EpisodeId);
            
            CreateTable(
                "MyAnime.Type",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "MyAnime.WriterSerie",
                c => new
                    {
                        WriterSerieId = c.Int(nullable: false, identity: true),
                        WriterId = c.Int(nullable: false),
                        SerieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WriterSerieId)
                .ForeignKey("MyAnime.Serie", t => t.SerieId, cascadeDelete: true)
                .ForeignKey("MyAnime.Writer", t => t.WriterId, cascadeDelete: true)
                .Index(t => t.WriterId)
                .Index(t => t.SerieId);
            
            CreateTable(
                "MyAnime.Writer",
                c => new
                    {
                        WriterId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.WriterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("MyAnime.WriterSerie", "WriterId", "MyAnime.Writer");
            DropForeignKey("MyAnime.WriterSerie", "SerieId", "MyAnime.Serie");
            DropForeignKey("MyAnime.Serie", "User_UserId", "MyAnime.AppUser");
            DropForeignKey("MyAnime.Serie", "TypeId", "MyAnime.Type");
            DropForeignKey("MyAnime.SerieCategory", "SerieId", "MyAnime.Serie");
            DropForeignKey("MyAnime.Episode", "User_UserId", "MyAnime.AppUser");
            DropForeignKey("MyAnime.UserEpisode", "UserID", "MyAnime.AppUser");
            DropForeignKey("MyAnime.UserEpisode", "EpisodeId", "MyAnime.Episode");
            DropForeignKey("MyAnime.AppUser", "Series_SerieId", "MyAnime.Serie");
            DropForeignKey("MyAnime.AppUser", "Episodes_EpisodeId", "MyAnime.Episode");
            DropForeignKey("MyAnime.Episode", "SerieId", "MyAnime.Serie");
            DropForeignKey("MyAnime.Serie", "ContentRatingId", "MyAnime.ContentRating");
            DropForeignKey("MyAnime.SerieCategory", "CategoryId", "MyAnime.Category");
            DropIndex("MyAnime.WriterSerie", new[] { "SerieId" });
            DropIndex("MyAnime.WriterSerie", new[] { "WriterId" });
            DropIndex("MyAnime.UserEpisode", new[] { "EpisodeId" });
            DropIndex("MyAnime.UserEpisode", new[] { "UserID" });
            DropIndex("MyAnime.AppUser", new[] { "Series_SerieId" });
            DropIndex("MyAnime.AppUser", new[] { "Episodes_EpisodeId" });
            DropIndex("MyAnime.AppUser", new[] { "EmailAddress" });
            DropIndex("MyAnime.AppUser", new[] { "UserName" });
            DropIndex("MyAnime.Episode", new[] { "User_UserId" });
            DropIndex("MyAnime.Episode", new[] { "SerieId" });
            DropIndex("MyAnime.Serie", new[] { "User_UserId" });
            DropIndex("MyAnime.Serie", new[] { "ContentRatingId" });
            DropIndex("MyAnime.Serie", new[] { "TypeId" });
            DropIndex("MyAnime.SerieCategory", new[] { "CategoryId" });
            DropIndex("MyAnime.SerieCategory", new[] { "SerieId" });
            DropTable("MyAnime.Writer");
            DropTable("MyAnime.WriterSerie");
            DropTable("MyAnime.Type");
            DropTable("MyAnime.UserEpisode");
            DropTable("MyAnime.AppUser");
            DropTable("MyAnime.Episode");
            DropTable("MyAnime.ContentRating");
            DropTable("MyAnime.Serie");
            DropTable("MyAnime.SerieCategory");
            DropTable("MyAnime.Category");
        }
    }
}
