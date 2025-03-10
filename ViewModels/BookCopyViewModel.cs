using Bookish.Models;
namespace Bookish.ViewModels;
public class BookCopyViewModel{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string BookTitle { get; set; }
    public DateTime? DateIn { get; set; }
    public DateTime? DateOut { get; set; }
    public DateTime? DateDue { get; set; }
    public BookCopyViewModel(BookCopy bookCopy) {
        Id = bookCopy.Id;
        UserName = bookCopy.User.Name;
        BookTitle = bookCopy.Book.Title;
        DateIn = bookCopy.DateIn;
        DateOut = bookCopy.DateOut;
        DateDue = bookCopy.DateDue;   
    }
}