using BookingHotelAPI.DAL.Context;
using BookingHotelAPI.DAL.Entitis;
using BookingHotelAPI.Repository.Interfaces;

namespace BookingHotelAPI.Repository.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private GenericRepository<Booking> bookingRepository;
        public IGenericRepository<Booking> BookingRepository
        {
            get
            {
                if (this.bookingRepository == null)
                {
                    this.bookingRepository = new GenericRepository<Booking>(_context);
                }
                return bookingRepository;
            }
        }

        private GenericRepository<Branche> brancheRepository;
        public IGenericRepository<Branche> BrancheRepository
        {
            get
            {
                if (this.brancheRepository == null)
                {
                    this.brancheRepository = new GenericRepository<Branche>(_context);
                }
                return brancheRepository;
            }
        }

        private GenericRepository<Meal> mealsRepository;
        public IGenericRepository<Meal> MealsRepository
        {
            get
            {
                if (this.mealsRepository == null)
                {
                    this.mealsRepository = new GenericRepository<Meal>(_context);
                }
                return mealsRepository;
            }
        }

        private GenericRepository<Room> roomRepository;
        public IGenericRepository<Room> RoomRepository
        {
            get
            {
                if (this.roomRepository == null)
                {
                    this.roomRepository = new GenericRepository<Room>(_context);
                }
                return roomRepository;
            }
        }
        
        private GenericRepository<RoomType> roomTypeRepository;
        public IGenericRepository<RoomType> RoomTypeRepository
        {
            get
            {
                if (this.roomTypeRepository == null)
                {
                    this.roomTypeRepository = new GenericRepository<RoomType>(_context);
                }
                return roomTypeRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

    }
}
