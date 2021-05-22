namespace MyAnime_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteOfWriterSeries : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("MyAnime.WriterSerie", "SerieId", "MyAnime.Serie");
            DropForeignKey("MyAnime.WriterSerie", "WriterId", "MyAnime.Writer");
            DropIndex("MyAnime.WriterSerie", new[] { "WriterId" });
            DropIndex("MyAnime.WriterSerie", new[] { "SerieId" });
            AddColumn("MyAnime.Serie", "WriterId", c => c.Int(nullable: false));
            CreateIndex("MyAnime.Serie", "WriterId");
            AddForeignKey("MyAnime.Serie", "WriterId", "MyAnime.Writer", "WriterId", cascadeDelete: true);
            DropTable("MyAnime.WriterSerie");
        }
        
        public override void Down()
        {
            CreateTable(
                "MyAnime.WriterSerie",
                c => new
                    {
                        WriterSerieId = c.Int(nullable: false, identity: true),
                        WriterId = c.Int(nullable: false),
                        SerieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WriterSerieId);
            
            DropForeignKey("MyAnime.Serie", "WriterId", "MyAnime.Writer");
            DropIndex("MyAnime.Serie", new[] { "WriterId" });
            DropColumn("MyAnime.Serie", "WriterId");
            CreateIndex("MyAnime.WriterSerie", "SerieId");
            CreateIndex("MyAnime.WriterSerie", "WriterId");
            AddForeignKey("MyAnime.WriterSerie", "WriterId", "MyAnime.Writer", "WriterId", cascadeDelete: true);
            AddForeignKey("MyAnime.WriterSerie", "SerieId", "MyAnime.Serie", "SerieId", cascadeDelete: true);
        }
    }
}
