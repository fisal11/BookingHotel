namespace BookingHotelAPI.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
            IEnumerable<TEntity> Get();
            TEntity GetById(object Id);
            void Add(TEntity entity);
            void Edit(int id ,TEntity entity);
            void Delete(int id);
        
    }
}
