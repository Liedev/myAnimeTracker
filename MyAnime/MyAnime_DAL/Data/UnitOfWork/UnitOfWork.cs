using MyAnime_DAL.Data.Repositories;

namespace MyAnime_DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region attributes
        IRepository<Category> _categoryRepo;
        IRepository<ContentRating> _contentRatingRepo;
        IRepository<Episode> _episodeRepo;
        IRepository<Serie> _serieRepo;
        IRepository<Type> _typeRepo;
        IRepository<AppUser> _userRepo;
        IRepository<Writer> _writerRepo;
        IRepository<SerieCategory> _serieCategoryRepo;
        IRepository<UserEpisode> _userEpisodeRepo;
        #endregion

        public UnitOfWork(MyAnimeEntities myAnimeEntities)
        {
            this.MyAnimeEntities = myAnimeEntities;
        }
        private MyAnimeEntities MyAnimeEntities { get; }

        #region repositories
        public IRepository<Category> CategoryRepo
        {
            get
            {
                if (_categoryRepo == null)
                {
                    _categoryRepo = new Repository<Category>(this.MyAnimeEntities);
                }
                return _categoryRepo;
            }
        }
        public IRepository<ContentRating> ContentRatingRepo
        {
            get
            {
                if (_contentRatingRepo == null)
                {
                    _contentRatingRepo = new Repository<ContentRating>(this.MyAnimeEntities);
                }
                return _contentRatingRepo;
            }
        }
        public IRepository<Episode> EpisodeRepo
        {
            get
            {
                if (_episodeRepo == null)
                {
                    _episodeRepo = new Repository<Episode>(this.MyAnimeEntities);
                }
                return _episodeRepo;
            }
        }
        public IRepository<Serie> SerieRepo
        {
            get
            {
                if (_serieRepo == null)
                {
                    _serieRepo = new Repository<Serie>(this.MyAnimeEntities);
                }
                return _serieRepo;
            }
        }
        public IRepository<Type> TypeRepo
        {
            get
            {
                if (_typeRepo == null)
                {
                    _typeRepo = new Repository<Type>(this.MyAnimeEntities);
                }
                return _typeRepo;
            }
        }
        public IRepository<AppUser> UserRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new Repository<AppUser>(this.MyAnimeEntities);
                }
                return _userRepo;
            }
        }
        public IRepository<Writer> WriterRepo
        {
            get
            {
                if (_writerRepo == null)
                {
                    _writerRepo = new Repository<Writer>(this.MyAnimeEntities);
                }
                return _writerRepo;
            }
        }
        public IRepository<SerieCategory> SerieCategoryRepo
        {
            get
            {
                if (_serieCategoryRepo == null)
                {
                    _serieCategoryRepo = new Repository<SerieCategory>(this.MyAnimeEntities);
                }
                return _serieCategoryRepo;
            }
        }
        public IRepository<UserEpisode> UserEpisodeRepo
        {
            get
            {
                if (_userEpisodeRepo == null)
                {
                    _userEpisodeRepo = new Repository<UserEpisode>(this.MyAnimeEntities);
                }
                return _userEpisodeRepo;
            }
        }

        #endregion

        public void Dispose()
        {
            MyAnimeEntities.Dispose();
        }

        public int Save()
        {
            return MyAnimeEntities.SaveChanges();
        }
    }
}
