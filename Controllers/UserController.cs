using Bookish.Database;
using Bookish.Models;
using Bookish.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Bookish.Controllers{
    public class UserController:Controller{
        private readonly BookishDBContext _context;        
        public UserController(BookishDBContext context){
            _context = context;
        }       
        public IActionResult AddUser(){
            return View("AddUser");
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([Bind("Id,Name")] UserViewModel userViewModel){
            _context.User.Add(new User(userViewModel));
             await _context.SaveChangesAsync();
             return RedirectToAction("ViewUser");
        }
        public async Task<IActionResult> ViewUser(){
            List<UserViewModel> users =_context.User.Select(user => new UserViewModel(user)).ToList();
            return View(users);
        }
    }
}