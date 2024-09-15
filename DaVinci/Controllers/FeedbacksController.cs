using Microsoft.AspNetCore.Mvc;
using DaVinci.Models;
using DaVinci.Service.InterfacesService;

namespace DaVinci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbacksService _feedbacksService;

        public FeedbacksController(IFeedbacksService feedbacksService)
        {
            _feedbacksService = feedbacksService;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedbacks>>> GetFeedbacks()
        {
            var feedbacks = await _feedbacksService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedbacks>> GetFeedback(int id)
        {
            var feedback = await _feedbacksService.GetFeedbacksByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        // POST: api/Feedbacks
        [HttpPost]
        public async Task<ActionResult<Feedbacks>> PostFeedback([FromBody] Feedbacks feedback)
        {
            var createdFeedback = await _feedbacksService.CreateFeedbacksAsync(feedback);
            return CreatedAtAction(nameof(GetFeedback), new { id = createdFeedback.IdFeedback }, createdFeedback);
        }

        // PUT: api/Feedbacks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, [FromBody] Feedbacks feedback)
        {
            if (id != feedback.IdFeedback)
            {
                return BadRequest();
            }
            try
            {
                await _feedbacksService.UpdateFeedbacksAsync(id, feedback);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                await _feedbacksService.DeleteFeedbacksAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
