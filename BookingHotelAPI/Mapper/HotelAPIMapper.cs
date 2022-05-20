using AutoMapper;
using BookingHotelAPI.DAL.Entitis;
using BookingHotelAPI.Model;

namespace BookingHotelAPI.Mapper
{
    public class HotelAPIMapper :   Profile
    {
        public HotelAPIMapper()
        {
            CreateMap<Booking, BookingVM>().ReverseMap();
            CreateMap<Branche, BrancheVM>().ReverseMap();
            CreateMap<Meal, MealVM>().ReverseMap();
            CreateMap<Room, RoomVM>().ReverseMap();
            CreateMap<RoomType, RoomTypeVM>().ReverseMap();
        }
    }
}
