using AutoMapper;
using SneakerMarket.Api.Dto.Contact;

namespace SneakerMarket.Api.Dto.CustomerInfo
{
    public class FeedbackDtoProfile: Profile
    {
        public FeedbackDtoProfile()
        {
            CreateMap<CreateUserDto, Models.CustomerInfo>()
            .ForMember(m => m.City, opt => opt.MapFrom(x => x.City))
            .ForMember(m => m.CustomerDiscount, opt => opt.MapFrom(x => 0));

            CreateMap<ContactUpdateDto, Models.CustomerInfo>()
            .ForMember(m => m.City, opt =>
            {
                opt.PreCondition(x => x.City is null);
                opt.UseDestinationValue();
            })
            .ForMember(m => m.City, opt =>
            {
                opt.PreCondition(x => x.City !=  null);
                opt.UseDestinationValue();
            })
            .ForMember(m => m.CustomerDiscount, opt => opt.UseDestinationValue())
            .ForMember(m => m.CustomerAccountId, opt => opt.UseDestinationValue());
        }
    }
}
