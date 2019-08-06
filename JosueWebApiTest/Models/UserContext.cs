using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JosueWebApiTest.Models
{
    public class UserContext : DbContext, IUserContext
    {

        public UserContext() : base()
        {
            this.Database.CommandTimeout = 180;
        }

        public DbSet<User> Users{get;set;}

        List<User> IUserContext.Users
        {
            get { return Users.ToList(); }
        }

        int IUserContext.SaveChanges()
        {
            return SaveChanges();
        }

        T IUserContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        User IUserContext.FindUserById(int ID)
        {
            return Set<User>().Find(ID);
        }

        T IUserContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }

    }
}