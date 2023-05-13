using AutoMapper;

namespace SneakerMarket.Api.Dto.Contact
{
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateUserDto, SneakerMarket.Api.Models.Contact>()
            .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(m => m.Surname, opt => opt.MapFrom(x => x.Surname))
            .ForMember(m => m.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber))
            .ForMember(m => m.Id, opt => opt.MapFrom(x => Guid.NewGuid()));

            CreateMap<ContactUpdateDto, SneakerMarket.Api.Models.Contact>()
            .ForMember(m => m.Name, opt =>
            {
                opt.PreCondition(x => x.Name != null);
                opt.MapFrom(x => x.Name);
            })
            .ForMember(m => m.Name, opt =>
            {
                opt.PreCondition(x => x.Name == null);
                opt.UseDestinationValue();
            })
            .ForMember(m => m.Surname, opt =>
            {
                opt.PreCondition(x => x.Surname != null);
                opt.MapFrom(x => x.Surname);
            })
            .ForMember(m => m.Surname, opt =>
            {
                opt.PreCondition(x => x.Surname == null);
                opt.UseDestinationValue();
            })
            .ForMember(m => m.PhoneNumber, opt =>
            {
                opt.PreCondition(x => x.PhoneNumber != null);
                opt.MapFrom(x => x.PhoneNumber);
            })
            .ForMember(m => m.PhoneNumber, opt =>
            {
                opt.PreCondition(x => x.PhoneNumber == null);
                opt.UseDestinationValue();
            })
            .ForMember(m => m.Id, opt => opt.UseDestinationValue())
            .ForMember(m => m.AccountId, opt => opt.UseDestinationValue());
        }
    }
}
