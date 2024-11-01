using Library.AppDBContext;
using Library.DTO;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        // Lấy danh sách sách
        [HttpGet("get-books")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _context.bookss.ToListAsync();
            return Ok(books);
        }

        // Lấy thông tin sách theo ID
        [HttpGet("get-book/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _context.bookss.FindAsync(id);
            if (book == null)
                return NotFound("Book not found");

            return Ok(book);
        }

        // Thêm sách
        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook([FromBody] BookDTO addBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = new books
            {
                title = addBook.title,
                image = addBook.image,
                subtitle = addBook.subtitle,
                authors_ID = addBook.authors_ID,
                genres_ID = addBook.genres_ID,
                publishing_Year = addBook.publishing_Year,
                quantity_In_Stock = addBook.quantity_In_Stock,
                description = addBook.description,
                create_At = DateTime.UtcNow,
                update_At = DateTime.UtcNow,
                delete_Flag = false
            };

            await _context.bookss.AddAsync(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        // Sửa sách
        [HttpPut("update-book/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDTO updateBook)
        {
            var book = await _context.bookss.FindAsync(id);
            if (book == null)
                return NotFound("Book not found");

            book.title = updateBook.title;
            book.image = updateBook.image;
            book.subtitle = updateBook.subtitle;
            book.authors_ID = updateBook.authors_ID;
            book.genres_ID = updateBook.genres_ID;
            book.publishing_Year = updateBook.publishing_Year;
            book.quantity_In_Stock = updateBook.quantity_In_Stock;
            book.description = updateBook.description;
            book.update_At = DateTime.UtcNow;

            _context.bookss.Update(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        // Xóa sách
        [HttpDelete("delete-book/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.bookss.FindAsync(id);
            if (book == null)
                return NotFound("Book not found");

            _context.bookss.Remove(book);
            await _context.SaveChangesAsync();
            return Ok("Book deleted successfully");
        }
    }
}