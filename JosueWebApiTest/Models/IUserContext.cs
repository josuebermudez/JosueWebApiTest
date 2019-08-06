using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosueWebApiTest.Models
{
    public interface IUserContext
    {
        List<User> Users { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;

        User FindUserById(int ID);
        T Delete<T>(T entity) where T : class;
    }
}
