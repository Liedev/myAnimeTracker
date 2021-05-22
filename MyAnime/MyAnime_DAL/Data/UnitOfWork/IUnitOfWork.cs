using MyAnime_DAL.Data.Repositories;
using System;

namespace MyAnime_DAL.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Category> CategoryRepo { get; }
        IRepository<ContentRating> ContentRatingRepo { get; }
        IRepository<Episode> EpisodeRepo { get; }
        IRepository<Serie> SerieRepo { get; }
        IRepository<Type> TypeRepo { get; }
        IRepository<AppUser> UserRepo { get; }
        IRepository<Writer> WriterRepo { get; }
        IRepository<SerieCategory> SerieCategoryRepo { get; }
        IRepository<UserEpisode> UserEpisodeRepo { get; }
        int Save();
    }
}
