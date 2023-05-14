using AutoMapper;
using SneakerMarket.Api.Dto.Contact;
using SneakerMarket.Api.Models;

namespace SneakerMarket.Api.Dto.FeedbackDto
{
    public class FeedbackDtoProfile: Profile
    {
        public FeedbackDtoProfile()
        {
            CreateMap<FeedbackDto, Feedback>()
            .ForMember(m => m.Feedback1, opt => opt.MapFrom(x => x.Feedback))
            .ForMember(m => m.CustomerRated, opt => opt.MapFrom(x => x.CustomerRated))
            .ForMember(m => m.Date, opt => opt.MapFrom(x => DateTime.UtcNow))
            .ForMember(m => m.CustomerOrderId, opt => opt.MapFrom(x => x.CustomerOrderId))
            .ForMember(m => m.Id, opt => opt.MapFrom(x=> Guid.NewGuid()));
        }
    }
}
