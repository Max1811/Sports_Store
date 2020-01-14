using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Data.Entities;
using Store.Data.ApplicationContext;

namespace Store.Data.InicializationData
{
    public class UsersData
    {
        public List<User> users = new List<User>()
        {
            new User("Kolya", new Guid("099E324F-695B-402E-BAB8-08D79752B010")),
            new User("Ivan"),
            new User("Sally"),
            new User("Oleg"),
            new User("Alex"),
            new User("Tanya"),
            new User("Piter"),
            new User("Garic"),
            new User("Olesya"),
            new User("Katty"),
        };
    }
}
