using BookingHotelAPI.DAL.Entitis;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingHotelAPI.DAL.Context
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Branche> Branches { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }

    }
}
