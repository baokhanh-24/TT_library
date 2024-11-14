using Library.AppDBContext;
using Library.DTO;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class RatingController : Controller
    {
        private readonly LibraryContext _context;

        public RatingController(LibraryContext context)
        {
            _context = context;
        }

        // GET: List all ratings
        [HttpGet]
        public async Task<IActionResult> ListRating()
        {
            var ratings = await _context.ratingss.ToListAsync();
            return View(ratings);
        }

        // POST: Add a new rating
        [HttpPost]
        public async Task<IActionResult> AddRating(RatingDTO addrating)
        {
            var rating = new ratings()
            {
                ratings_ID = addrating.ratings_ID,
                books_ID = addrating.books_ID,
                users_ID = addrating.users_ID,
                star = addrating.star,
                create_At = addrating.create_At,
                update_At = addrating.update_At,
                delete_Flag = addrating.delete_Flag
            };

            await _context.ratingss.AddAsync(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction("ListRating");
        }

        // GET: Edit a rating by ID
        [HttpGet]
        public async Task<IActionResult> EditRating(int id)
        {
            var rating = await _context.ratingss.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            var ratingDTO = new RatingDTO
            {
                ratings_ID = rating.ratings_ID,
                books_ID = rating.books_ID,
                users_ID = rating.users_ID,
                star = rating.star,
                create_At = rating.create_At,
                update_At = rating.update_At,
                delete_Flag = rating.delete_Flag
            };

            return View(ratingDTO);
        }

        // POST: Update an existing rating
        [HttpPost]
        public async Task<IActionResult> EditRating(RatingDTO editrating)
        {
            var rating = await _context.ratingss.FindAsync(editrating.ratings_ID);
            if (rating == null)
            {
                return NotFound();
            }

            rating.books_ID = editrating.books_ID;
            rating.users_ID = editrating.users_ID;
            rating.star = editrating.star;
            rating.create_At = editrating.create_At;
            rating.update_At = editrating.update_At;
            rating.delete_Flag = editrating.delete_Flag;

            _context.ratingss.Update(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction("ListRating");
        }

        // POST: Delete a rating by ID
        [HttpPost]
        public async Task<IActionResult> DeleteRating(int id)
        {
            var rating = await _context.ratingss.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            _context.ratingss.Remove(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction("ListRating");
        }
    }
}
