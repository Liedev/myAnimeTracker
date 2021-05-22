namespace MyAnime_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescriptionToEpisodeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("MyAnime.Episode", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("MyAnime.Episode", "Description");
        }
    }
}
