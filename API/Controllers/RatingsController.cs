using Library.AppDBContext;
using Library.DTO;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly LibraryContext _context;

        public RatingController(LibraryContext context)
        {
            _context = context;
        }

        // Lấy danh sách rating
        [HttpGet("get-ratings")]
        public async Task<IActionResult> GetRatings()
        {
            var ratings = await _context.ratingss.ToListAsync();
            return Ok(ratings);
        }

        // Lấy thông tin rating theo ID
        [HttpGet("get-rating/{id}")]
        public async Task<IActionResult> GetRatingById(int id)
        {
            var rating = await _context.ratingss.FindAsync(id);
            if (rating == null)
                return NotFound("Rating not found");

            return Ok(rating);
        }

        // Thêm rating
        [HttpPost("add-rating")]
        public async Task<IActionResult> AddRating([FromBody] RatingDTO addRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rating = new ratings
            {
                books_ID = addRating.books_ID,
                users_ID = addRating.users_ID,
                star = addRating.star,
                create_At = DateTime.UtcNow,
                update_At = DateTime.UtcNow,
                delete_Flag = false
            };

            await _context.ratingss.AddAsync(rating);
            await _context.SaveChangesAsync();
            return Ok(rating);
        }

        // Sửa rating
        [HttpPut("update-rating/{id}")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] RatingDTO updateRating)
        {
            var rating = await _context.ratingss.FindAsync(id);
            if (rating == null)
                return NotFound("Rating not found");

            rating.books_ID = updateRating.books_ID;
            rating.users_ID = updateRating.users_ID;
            rating.star = updateRating.star;
            rating.update_At = DateTime.UtcNow;

            _context.ratingss.Update(rating);
            await _context.SaveChangesAsync();
            return Ok(rating);
        }

        // Xóa rating
        [HttpDelete("delete-rating/{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            var rating = await _context.ratingss.FindAsync(id);
            if (rating == null)
                return NotFound("Rating not found");

            _context.ratingss.Remove(rating);
            await _context.SaveChangesAsync();
            return Ok("Rating deleted successfully");
        }
    }
}
