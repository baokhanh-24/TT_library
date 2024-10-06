using Library.AppDBContext;
using Library.DTO;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        public readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListBook()
        {
            var books = await _context.bookss.ToListAsync();
            return View(books);
        }



        [HttpPost]
        public async Task<IActionResult> AddBook(BookDTO addbook)
        {
            var book = new books()
            {
                books_ID = addbook.books_ID,
                title = addbook.title,
                image = addbook.image,
                subtitle = addbook.subtitle,
                authors_ID = addbook.authors_ID,
                genres_ID = addbook.genres_ID,
                publishing_Year = addbook.publishing_Year,
                quantity_In_Stock = addbook.quantity_In_Stock,
                description = addbook.description,
                create_At = addbook.create_At,
                update_At = addbook.update_At,
                delete_Flag = addbook.delete_Flag,

            };

            await _context.bookss.AddAsync(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("AddBook");
        }
    }
}
