using Bookish.Models;
namespace Bookish.ViewModels;
public class AuthorViewModel {
    public int Id {get;set;} 
    public string Name{get;set;}
    public AuthorViewModel() {}
    public AuthorViewModel(Author author){
        Id = author.Id;
        Name = author.Name;
    }
}