using System;
using System.Linq;
using JosueWebApiTest.Models;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using JosueWebApiTest.Controllers;

namespace UserControllerTest
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void GetUserListTest()
        {
            User user = new User();
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.SetupGet(uc=> uc.Users).Returns(new List<User>());

            UserController controller = new UserController(mockUserContext.Object);
            var result = controller.Get();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            User user = new User();
            int id = 0;
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.Setup(uc => uc.FindUserById(id)).Returns(new User());

            UserController controller = new UserController(mockUserContext.Object);
            var result = controller.Get(id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateUserTest()
        {
            User user = new User();
            int id = 0;
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.Setup(uc => uc.Add(user)).Returns(new User());
            mockUserContext.Setup(uc => uc.SaveChanges()).Returns(id);

            UserController controller = new UserController(mockUserContext.Object);
            var result = controller.Post(user);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            User user = new User();
            int id = 0;
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.Setup(uc => uc.FindUserById(id)).Returns(new User());
            mockUserContext.Setup(uc => uc.SaveChanges()).Returns(id);

            UserController controller = new UserController(mockUserContext.Object);
            var result = controller.Put(id, user);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            User user = new User();
            int id = 0;
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.Setup(uc => uc.FindUserById(id)).Returns(new User());
            mockUserContext.Setup(uc => uc.Delete(user)).Returns(new User());
            mockUserContext.Setup(uc => uc.SaveChanges()).Returns(id);

            UserController controller = new UserController(mockUserContext.Object);
            var result = controller.Delete(id);
            Assert.IsNotNull(result);
        }
    }
}
