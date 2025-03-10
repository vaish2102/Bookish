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
         /*   BookCopy? bookCopy =_context.BookCopy.Where(bookCopy => bookCopy.Book.Title == bookViewModel.Title).FirstOrDefault();
            if(bookCopy == null){

                bookCopy = new BookCopy(){};
                _context.BookCopy.Add(bookCopy);
            }
            BookCopyViewModel bookCopyViewModel = new BookCopyViewModel({'Test',
        BookTitle,DateIn,DateOut,DateDue})
             _context.BookCopy.Add(new BookCopy(bookViewModel,book,user));*/
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

        public async Task<IActionResult> AddBookCopy([Bind("Id,UserName,BookTitle,DateIn,DateOut,DateDue")] BookCopyViewModel bookCopyViewModel){

            User? user =_context.User.Where(user => user.Name == bookCopyViewModel.UserName).FirstOrDefault();
            if(user == null){
                user = new User(){Name = bookCopyViewModel.UserName};
                _context.User.Add(user);
            }
            Book? book =_context.Book.Where(book => book.Title == bookCopyViewModel.BookTitle).FirstOrDefault();
            if(book == null){
                book = new Book(){Title = bookCopyViewModel.BookTitle};
                _context.Book.Add(book);
            }
            _context.BookCopy.Add(new BookCopy(bookCopyViewModel,book,user));
             await _context.SaveChangesAsync();
             return RedirectToAction("ViewBook");
        }
    }
}