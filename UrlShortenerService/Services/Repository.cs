using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrlShortenerService.Data;

namespace UrlShortenerService.Services
{

    public interface IRepository
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        TEntity Get<TEntity>(object Id) where TEntity : class;
        List<TEntity> GetAll<TEntity>() where TEntity : class;


    }
    public class UrlShortenerRepository : IRepository
    {
        DatabaseContext dbContext;
        public UrlShortenerRepository()
        {
            dbContext = new DatabaseContext();
        }
        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }

        public TEntity Get<TEntity>(object Id) where TEntity : class
        {
            return dbContext.Set<TEntity>().Find(Id);
        }

        public List<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return dbContext.Set<TEntity>().AsNoTracking().ToList();
        }
    }
}