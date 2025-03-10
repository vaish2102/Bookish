using Bookish.Models;
namespace Bookish.ViewModels;
public class BookViewModel {
    public int Id {get;set;} 
    public string Title{get;set;}
    public string AuthorName{get;set;}
    public BookViewModel() {}
    public BookViewModel(Book book){
        Id = book.Id;
        Title = book.Title;
        AuthorName = book.Author.Name;
    }
}