using Bookish.Models;
namespace Bookish.ViewModels;
public class UserViewModel {
    public int Id {get;set;} 
    public string Name{get;set;}
    public UserViewModel() {}
    public UserViewModel(User user){
        Id = user.Id;
        Name = user.Name;
    }
}