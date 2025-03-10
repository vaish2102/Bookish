using Bookish.ViewModels;
namespace Bookish.Models;
public class BookCopy{
    public int Id { get; set;}
    public User? User { get; set; }
    public Book Book { get; set; }
    public DateTime? DateIn { get; set; }
    public DateTime? DateOut { get; set; }
    public DateTime? DateDue { get; set; }
    public BookCopy (BookCopyViewModel bookCopyViewModel, Book book, User user){
        Id = bookCopyViewModel.Id;
        User = user;
        Book = book;
        DateIn = bookCopyViewModel.DateIn;
        DateOut = bookCopyViewModel.DateOut;
        DateDue = bookCopyViewModel.DateDue;
    }

    public BookCopy(){}

}