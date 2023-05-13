using System.ComponentModel.DataAnnotations;

namespace SneakerMarket.Api.Dto.Account
{
    public class AccountUpdateDto
    {
        [Required]
        public string Password { get; set; } = null!;
    }
}
