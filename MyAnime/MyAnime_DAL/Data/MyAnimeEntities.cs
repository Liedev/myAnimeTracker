using System.Data.Entity;

namespace MyAnime_DAL.Data
{
    public class MyAnimeEntities: DbContext
    {
        public MyAnimeEntities():base("name=MyAnimeDbConnectionString") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ContentRating> ContentRatings { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<SerieCategory> SerieCategories { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserEpisode> UserEpisodes { get; set; }
        public DbSet<Writer> Writers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("MyAnime");
            /*https://stackoverflow.com/questions/17127351/introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths
                This is from 7 years ago but still works*/
            modelBuilder.Entity<AppUser>()
                .HasOptional(c => c.Series)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<AppUser>()
                .HasOptional(c => c.Episodes)
                .WithMany()
                .WillCascadeOnDelete(false);
            /*            Switched to Data Annotations
                          #region Category
                        modelBuilder.Entity<Category>()
                            .ToTable("Category")
                            .HasKey(pKey => pKey.CategoryId)
                            .Property(category => category.Name)
                            .HasMaxLength(255)
                            .IsRequired();
                        #endregion
                        #region ContentRatings
                        modelBuilder.Entity<ContentRating>()
                            .ToTable("ContentRating")
                            .HasKey(pKey => pKey.ContentRatingId)
                            .Property(contentRating => contentRating.Image)
                            .HasMaxLength(2083)
                            .IsRequired();
                        modelBuilder.Entity<ContentRating>()
                            .Property(contentRating => contentRating.Rating)
                            .HasMaxLength(255)
                            .IsRequired();
                        #endregion
                        #region Episode
                        modelBuilder.Entity<Episode>()
                            .ToTable("Episode")
                            .HasKey(pKey => pKey.EpisodeId)
                            .Property(episode => episode.Name)
                            .HasMaxLength(255)
                            .IsRequired();
                        modelBuilder.Entity<Episode>()
                            .Property(episode => episode.Image)
                            .HasMaxLength(2083)
                            .IsRequired();
                        modelBuilder.Entity<Episode>()
                            .Property(episode => episode.Number)
                            .IsRequired();
                        modelBuilder.Entity<Episode>()
                            .Property(episode => episode.ReleaseDate)
                            .IsRequired();
                        modelBuilder.Entity<Episode>()
                            .Property(episode => episode.Season)
                            .IsRequired();
                        modelBuilder.Entity<Episode>()
                            .Property(episode => episode.SerieId)
                            .IsRequired();
                        modelBuilder.Entity<Episode>()
                            .Property(episode => episode.UserId)
                            .IsRequired();

                        #endregion
                        #region Serie
                        modelBuilder.Entity<Serie>()
                            .ToTable("Serie")
                            .HasKey(pKey => pKey.SerieId)
                            .Property(serie => serie.Name)
                            .HasMaxLength(255)
                            .IsRequired();
                        modelBuilder.Entity<Serie>()
                            .Property(serie => serie.Discription)
                            .IsRequired();
                        modelBuilder.Entity<Serie>()
                           .Property(serie => serie.Image)
                           .IsRequired()
                           .HasColumnType("image");
                        modelBuilder.Entity<Serie>()
                           .Property(serie => serie.AirDate)
                           .IsRequired();
                        modelBuilder.Entity<Serie>()
                           .Property(serie => serie.Discription)
                           .IsRequired();
                        modelBuilder.Entity<Serie>()
                           .Property(serie => serie.TypeId)
                           .IsRequired();
                        modelBuilder.Entity<Serie>()
                           .Property(serie => serie.ContentRatingId)
                           .IsRequired();
                        modelBuilder.Entity<Serie>()
                           .Property(serie => serie.UserId)
                           .IsRequired();
                        #endregion
                        #region SerieCategory
                        modelBuilder.Entity<SerieCategory>()
                            .ToTable("SerieCategory")
                            .HasKey(pkey => pkey.SerieCategoryId)
                            .Property(serieCategory => serieCategory.SerieId)
                            .IsRequired();
                        modelBuilder.Entity<SerieCategory>()
                            .Property(serieCategory => serieCategory.CategoryId)
                            .IsRequired();
                        #endregion
                        #region Type
                        modelBuilder.Entity<Type>()
                            .ToTable("Type")
                            .HasKey(pKey => pKey.TypeID)
                            .Property(type => type.Name)
                            .IsRequired();
                        #endregion
                        #region AppUser
                        modelBuilder.Entity<AppUser>()
                            .ToTable("AppUser")
                            .HasKey(pKey => pKey.UserId)
                            .Property(user => user.UserName)
                            .HasMaxLength(255)
                            .IsRequired();
                        modelBuilder.Entity<AppUser>()
                            .Property(user => user.EmailAddress)
                            .HasMaxLength(450)
                            .IsRequired();
                        modelBuilder.Entity<AppUser>()
                            .HasIndex(user => user.EmailAddress)
                            .IsUnique();
                        modelBuilder.Entity<AppUser>()
                           .Property(user => user.PasswordHash)
                           .HasMaxLength(450)
                           .IsRequired();
                        modelBuilder.Entity<AppUser>()
                            .HasIndex(user => user.PasswordHash)
                            .IsUnique();
                        modelBuilder.Entity<AppUser>()
                           .Property(user => user.IsAdmin)
                           .IsRequired();
                        *//*https://stackoverflow.com/questions/17127351/introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths
                            This is from 7 years ago but still works*//*
                        modelBuilder.Entity<AppUser>()
                            .HasOptional(c => c.Series)
                            .WithMany()
                            .WillCascadeOnDelete(false);
                        modelBuilder.Entity<AppUser>()
                            .HasOptional(c => c.Episodes)
                            .WithMany()
                            .WillCascadeOnDelete(false);
                        #endregion
                        #region UserEpisode
                        modelBuilder.Entity<UserEpisode>()
                            .ToTable("UserEpisode")
                            .HasKey(pKey => pKey.UserEpisodeID)
                            .Property(userEpisode => userEpisode.UserID)
                            .IsRequired();
                        modelBuilder.Entity<UserEpisode>()
                            .Property(userEpisode => userEpisode.EpisodeId)
                            .IsRequired();
                        modelBuilder.Entity<UserEpisode>()
                            .Property(userEpisode => userEpisode.Watched)
                            .IsRequired();
                        #endregion
                        #region Writer
                        modelBuilder.Entity<Writer>()
                            .ToTable("Writer")
                            .HasKey(pKey => pKey.WriterId)
                            .Property(writer => writer.Name)
                            .IsRequired();
                        #endregion
                        #region WriterSerie
                        modelBuilder.Entity<WriterSerie>()
                            .ToTable("WriterSerie")
                            .HasKey(pkey => pkey.WriterSerieId)
                            .Property(writerserie => writerserie.WriterId)
                            .IsRequired();
                        modelBuilder.Entity<WriterSerie>()
                            .Property(writerserie => writerserie.SerieId)
                            .IsRequired();
                        #endregion*/
        }
    }
}
