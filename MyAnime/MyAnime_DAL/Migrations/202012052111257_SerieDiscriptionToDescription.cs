namespace MyAnime_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SerieDiscriptionToDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("MyAnime.Serie", "Description", c => c.String(nullable: false));
            DropColumn("MyAnime.Serie", "Discription");
        }
        
        public override void Down()
        {
            AddColumn("MyAnime.Serie", "Discription", c => c.String(nullable: false));
            DropColumn("MyAnime.Serie", "Description");
        }
    }
}
