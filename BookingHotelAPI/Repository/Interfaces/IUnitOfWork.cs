using BookingHotelAPI.DAL.Entitis;

namespace BookingHotelAPI.Repository.Interfaces
{

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Booking> BookingRepository { get; }
        IGenericRepository<Branche> BrancheRepository { get; }
        IGenericRepository<Meal> MealsRepository { get; }
        IGenericRepository<Room> RoomRepository { get; }
        IGenericRepository<RoomType> RoomTypeRepository { get; }
        void Save();

    }
}
