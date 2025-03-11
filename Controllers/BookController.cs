using System.ComponentModel.Design;
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
          BookCopy? bookCopy =_context.BookCopy.Where(bookCopy => bookCopy.Book.Title == bookViewModel.Title).FirstOrDefault();
          if(bookCopy == null){
                await AddBookCopy(bookViewModel);
          }
            else{
                await UpdateBookCopy(bookViewModel, bookCopy);
            }
            return RedirectToAction("ViewBook");
        }

        public async Task<IActionResult> AddBookCopy(BookViewModel bookViewModel){
            BookCopy bookCopy;
            Book? book = _context.Book.Where(book => book.Title == bookViewModel.Title).FirstOrDefault();
            BookCopyViewModel bookCopyViewModel = new BookCopyViewModel();
            bookCopyViewModel.BookTitle = bookViewModel.Title;              
            bookCopy = new BookCopy(bookCopyViewModel,book,null);
            _context.BookCopy.Add(bookCopy);
            await _context.SaveChangesAsync();
             return RedirectToAction("ViewBook");
        }  

         public async Task<IActionResult> UpdateBookCopy(BookViewModel bookViewModel, BookCopy bookCopy){
            bookCopy.Book.Title = bookViewModel.Title;
            _context.BookCopy.Update(bookCopy);
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

     //   public async Task<IActionResult> CheckOutBook([Bind("Id,UserName,BookTitle,DateIn,DateOut,DateDue")] BookCopyViewModel bookCopyViewModel){
        public async Task<IActionResult> CheckOutBook(BookViewModel bookViewModel){
            Console.WriteLine("inside checkout");
            string userName = "John Doe";
            User? user =_context.User.Where(user => user.Name == userName).FirstOrDefault();
            if(user == null){
                user = new User(){Name = userName};
                _context.User.Add(user);
            }
            
           BookCopy ?bookCopy =_context.BookCopy.Where(bookCopy => bookCopy.Book.Title == bookViewModel.Title).FirstOrDefault();
           if(bookCopy == null){
                Console.WriteLine("Would notbe null");
            }
            bookCopy.Book.Title = bookViewModel.Title;
            bookCopy.User.Name = user.Name;
            bookCopy.DateOut = DateTime.Now;
            bookCopy.DateDue = DateTime.Now.AddDays(14);
            _context.BookCopy.Update(bookCopy);
             await _context.SaveChangesAsync();
            return RedirectToAction("ViewBook");
        }

        public void checkOut(){
            Console.WriteLine("going to check out");
        }    

    }
}