namespace MyAnime_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSeasonFromEpisodeNotNeeded : DbMigration
    {
        public override void Up()
        {
            DropColumn("MyAnime.Episode", "Season");
        }
        
        public override void Down()
        {
            AddColumn("MyAnime.Episode", "Season", c => c.Int(nullable: false));
        }
    }
}
