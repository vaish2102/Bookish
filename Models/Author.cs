using Bookish.ViewModels;
namespace Bookish.Models;
public class Author{
    public int Id{get;set;}
    public string Name{get;set;}

     public Author(AuthorViewModel authorViewModel ){
        Id = authorViewModel.Id;
        Name = authorViewModel.Name;
    }
    public Author(){}

}