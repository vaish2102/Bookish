using Bookish.ViewModels;
namespace Bookish.Models;
public class Book{
    public int Id{get;set;}
    public string Title{get;set;}
    public Author Author {get;set;}
    public Book(BookViewModel bookViewModel,Author author ){
        Id = bookViewModel.Id;
        Title = bookViewModel.Title;
        Author = author;
    }
    public Book(){}
}