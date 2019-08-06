using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JosueWebApiTest.Models
{
    public class UserInitializer: DropCreateDatabaseAlways<UserContext>
    {

        protected override void Seed(UserContext context)
        {
            base.Seed(context);
            var users = new List<User>
            {
                new User{
                    Id = 1,
                    Name = "Josue",
                    LastName = "Bermudez",
                    Address = "fdsfsfds",
                    CreateDate = DateTime.Today.AddDays(-5),
                    UpdateDate = DateTime.Today.AddDays(-2)
                },
                new User{
                    Id = 1,
                    Name = "Pedro",
                    LastName = "Perez",
                    Address = "fdsfsfds",
                    CreateDate = DateTime.Today.AddDays(-5),
                    UpdateDate = DateTime.Today.AddDays(-2)
                },
                new User{
                    Id = 1,
                    Name = "Alberto",
                    LastName = "Suarez",
                    Address = "fdsfsfds",
                    CreateDate = DateTime.Today.AddDays(-5),
                    UpdateDate = DateTime.Today.AddDays(-2)
                },
                new User{
                    Id = 1,
                    Name = "Rafael",
                    LastName = "Hernandez",
                    Address = "fdsfsfds",
                    CreateDate = DateTime.Today.AddDays(-5),
                    UpdateDate = DateTime.Today.AddDays(-2)
                }


            };
            users.ForEach(u=> context.Users.Add(u));
            context.SaveChanges();

        }
    }
}