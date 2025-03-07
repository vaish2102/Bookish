using Bookish.ViewModels;
namespace Bookish.Models;
public class Book{
    public int Id{get;set;}
    public string Title{get;set;}
    public Book(BookViewModel bookViewModel ){
        Id = bookViewModel.Id;
        Title = bookViewModel.Title;
    }
    public Book(){}
}