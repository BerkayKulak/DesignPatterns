﻿using System;
using BaseProject.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApp.Observer.Models;

namespace WebApp.Observer.Observer
{
    public class UserObserverCreateDiscount:IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverCreateDiscount(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverCreateDiscount>>();

            var context = _serviceProvider.GetRequiredService<AppIdentityDbContext>();

            context.Discounts.Add(new Discount() {Rate = 10, UserId = appUser.Id});

            context.SaveChanges();

            logger.LogInformation("Discount row created");

        }
    }
}