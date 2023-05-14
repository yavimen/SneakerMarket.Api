using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using SneakerMarket.Api.Dto.Account;
using SneakerMarket.Api.Dto.Contact;
using SneakerMarket.Api.Dto;
using SneakerMarket.Api.Models;
using SneakerMarket.Api.Dto.FeedbackDto;

namespace SneakerMarket.Api.Controllers
{
    [Route("api/feedback")]
    public class FeedbackController : Controller
    {
        private readonly IRepositoryWrapper _wrapperRepository;
        private readonly IMapper _mapper;

        public FeedbackController(IRepositoryWrapper accountRepository, IMapper mapper)
        {
            _wrapperRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetFeedbacksByEmail(string email)
        {
            var feedbacks = await _wrapperRepository.Feedback.GetAllFeedbacksByEmailWithDetailsAsync(email);

            return Ok(feedbacks);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var feedbacks = await _wrapperRepository.Feedback.GetAllFeedbacksWithDetailsAsync();

            return Ok(feedbacks);
        }

        [HttpPost("{email}")]
        public async Task<IActionResult> CreateFeedback([FromBody] FeedbackDto feedbackDto)
        {
            var account = await _wrapperRepository.Account
                .GetAccountByEmailWithDetailsAsync(feedbackDto.Email);

            if (account != null)
            {
                return BadRequest("Account is not founded.");
            }

            var feedback = _mapper.Map<Feedback>(feedbackDto);
            feedback.CustomerContactId = account.Contacts.ToList()[0].Id;

            _wrapperRepository.Feedback.CreateFeedback(feedback);

            try
            {
                await _wrapperRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok("feedback created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccountById([FromRoute] Guid id)
        {
            var feedback = await _wrapperRepository.Feedback
                .GetFeedbackAsync(id);

            if (feedback == null)
            {
                return BadRequest("There is no feedback with this id.");
            }

            _wrapperRepository.Feedback.DeleteFeedback(feedback);

            await _wrapperRepository.SaveAsync();

            return Ok("feedback deleted");
        }
    }
}
