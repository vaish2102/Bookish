using Bookish.Database;
using Bookish.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Controllers{
    public class BookController:Controller{
        private readonly BookishDBContext _context;
        public BookController(BookishDBContext context){
            _context = context;
        }
        public async Task<IActionResult> ViewBook(){
            // List<MovieViewModel> movies = (await _context.Movie.Include(movie => movie.Director).ToListAsync()).Select(movie => new MovieViewModel(movie)).ToList();
           // List<BookViewModel> books = (await _context.Book.Include(book => book.Id).ToListAsync()).Select(book => new BookViewModel(book)).ToList();
           BookViewModel books = new BookViewModel();
            return View(books);
        }

    }
}