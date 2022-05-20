using BookingHotelAPI.DAL.Context;
using BookingHotelAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingHotelAPI.Repository.Repo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        ApplicationDbContext _context;
        DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            var deletdata = _dbSet.Find(id);
            _dbSet.Remove(deletdata);
            _context.SaveChanges();
        }
        public virtual void Edit(int id , TEntity entity)
        {
            _context.Attach(entity);
            _context.Update(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            var data = _dbSet.ToList();
            return data;

        }
        public virtual TEntity GetById(object Id)
        {
            return _dbSet.Find(Id);
        }
    }
}
