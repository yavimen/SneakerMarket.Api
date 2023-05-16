using AutoMapper;
using SneakerMarket.Api.Models;

namespace SneakerMarket.Api.Dto.CustomerOrderDto
{
    public class CustomerOrderProfile: Profile
    {
        public CustomerOrderProfile()
        {
            CreateMap<ShoesAdditionalInfo, ShoesInfoForGetOrderDto>()
            .ForMember(m => m.Quantity, opt => opt.MapFrom(x => x.Quantity))
            .ForMember(m => m.ShoesSize, opt => opt.MapFrom(x => x.ShoesSize))
            .ForMember(m => m.PricePerOne, opt => opt.MapFrom(x => x.PricePerOne));

            CreateMap<ShoesMain, MainShoesForGetOrderDto>()
            .ForMember(m => m.Category, opt => opt.MapFrom(x => x.Category.Category1))
            .ForMember(m => m.ShoesName, opt => opt.MapFrom(x => x.ShoesName))
            .ForMember(m => m.ShoesInfos, opt => opt.MapFrom(x => x.ShoesAdditionalInfos));

            CreateMap<CustomerOrder, CustomerGetOrderDto>()
            .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(m => m.Shoes, opt => opt.MapFrom(x => x.OrderShoesInfoMaps.Select(x => x.AdditionalInfo.ShoesMain)));
        }
    }
}
