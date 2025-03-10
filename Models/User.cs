using Bookish.ViewModels;
namespace Bookish.Models;
public class User{
    public int Id{get;set;}
    public string Name{get;set;}
    public User(UserViewModel userViewModel){
        Id = userViewModel.Id;
        Name = userViewModel.Name;
       
    }
    public User(){}

}