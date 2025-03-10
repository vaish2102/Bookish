using Bookish.Database;
using Bookish.Models;
using Bookish.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Bookish.Controllers{
    public class BookController:Controller{
        private readonly BookishDBContext _context;        
        public BookController(BookishDBContext context){
            _context = context;
        }       
        public IActionResult AddBook(){
            return View("AddBook");
        }
        [HttpPost]
        public async Task<IActionResult> AddBook([Bind("Id,Title,AuthorName")] BookViewModel bookViewModel){
            Author? author =_context.Author.Where(author => author.Name == bookViewModel.AuthorName).FirstOrDefault();
            if(author == null){
                author = new Author(){Name = bookViewModel.AuthorName};
                _context.Author.Add(author);
            }
            _context.Book.Add(new Book(bookViewModel,author));
             await _context.SaveChangesAsync();
             return RedirectToAction("ViewBook");
        }
        public async Task<IActionResult> ViewBook(){
           // var book = _context.Book.ToList();
            //List<MovieViewModel> movies = (await _context.Movie.Include(movie => movie.Director).ToListAsync()).Select(movie => new MovieViewModel(movie)).ToList();
             List<BookViewModel> books =(await _context.Book.Include(book => book.Author).ToListAsync()).Select(book => new BookViewModel(book)).ToList();
           // List<BookViewModel> books =_context.Book.Select(book => new BookViewModel(book)).ToList();
            return View(books);
        }
    }
}