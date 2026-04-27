using AutoMapper;
using EventBookingAPI.DTOs;
using EventBookingAPI.Models;

namespace EventBookingAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<CreateEventDto, Event>();

            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.EventTitle, opt => opt.MapFrom(src => src.Event.Title))
                .ForMember(dest => dest.EventLocation, opt => opt.MapFrom(src => src.Event.Location))
                .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Event.Date))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<User, UserDto>();
        }
    }
}
