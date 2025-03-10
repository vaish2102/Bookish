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
        public async Task<IActionResult> AddBook([Bind("Id,Title")] BookViewModel bookViewModel){
            _context.Add(new Book(bookViewModel));
             await _context.SaveChangesAsync();
             return RedirectToAction("ViewBook");
        }
        public async Task<IActionResult> ViewBook(){
            var book = _context.Book.ToList();
            List<BookViewModel> books =_context.Book.Select(book => new BookViewModel(book)).ToList();
            return View(books);
        }
    }
}