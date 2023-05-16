namespace SneakerMarket.Api.Dto.CustomerOrderDto
{
    public class CustomerGetOrderDto
    {
        public int Id { get; set; }

        public IEnumerable<MainShoesForGetOrderDto> Shoes { get; set; }
    }
    public class MainShoesForGetOrderDto
    {
        public string ShoesName { get; set; }
        public string Category { get; set; }
        public IEnumerable<ShoesInfoForGetOrderDto> ShoesInfos { get; set; }
    }
    public class ShoesInfoForGetOrderDto
    {
        public int ShoesSize { get; set; }
        public float PricePerOne { get; set; }
        public int Quantity { get; set; }
    }
}
