using Bookish.Database;
using Bookish.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Bookish.Controllers{
    public class BookController:Controller{
        private readonly BookishDBContext _context;        
        public BookController(){}
        public async Task<IActionResult> ViewBook(){
           BookViewModel testBook1 = new BookViewModel {
                Id = 1234,
                Title = "Test Book 1"
            };
            BookViewModel testBook2 = new BookViewModel {
                Id = 1235,
                Title = "Hitchhiker's Guide To The Galaxy"
            };
            List<BookViewModel> testBookList = new List<BookViewModel>();
            testBookList.Add(testBook1);
            testBookList.Add(testBook2);
            return View(testBookList);
        }
    }
}