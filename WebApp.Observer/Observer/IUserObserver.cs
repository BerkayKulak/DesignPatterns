using BaseProject.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Observer.Observer
{
    public interface IUserObserver
    {
        void UserCreated(AppUser appUser);
    }
}
