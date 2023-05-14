using System.ComponentModel.DataAnnotations;

namespace SneakerMarket.Api.Dto.FeedbackDto
{
    public class FeedbackDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string? Feedback { get; set; }

        [Required]
        public int CustomerRated { get; set; }

        [Required]
        public Guid CustomerOrderId { get; set; }
    }
}
