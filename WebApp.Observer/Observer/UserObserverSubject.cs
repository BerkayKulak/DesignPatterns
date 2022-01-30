﻿using System.Collections.Generic;
using BaseProject.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Observer.Observer
{
    public class UserObserverSubject
    {
        private readonly List<IUserObserver> _userObservers;

        public UserObserverSubject()
        {
            _userObservers = new List<IUserObserver>();
        }

        public void RegisterObserver(IUserObserver userObserver)
        {
            _userObservers.Add(userObserver);
        }

        public void RemoveObserver(IUserObserver userObserver)
        {
            _userObservers.Remove(userObserver);
        }

        public void NotifyObservers(AppUser appUser)
        {
            _userObservers.ForEach(x =>
            {

                x.UserCreated(appUser);
            });
        }
    }
}
