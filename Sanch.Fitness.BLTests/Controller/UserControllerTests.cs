using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sanch.Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        //[TestMethod()]
        //public void UserControllerTest()
        //{
        //    Assert.Fail();//предупреждение (вывод сообщения)
        //}

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange - объявление данных на вход и ожидаться на выходе
            //Act - действия (вызываем что то)
            //Assert - проверяем то что получилось и то что ожидалось

            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);//первое - ожидаемое , второе - то что получилось
            //AreEqual - равны между собой
            //AreNotEqual - неравны между собой
            //Fail - сразу фейл теста

        }

        [TestMethod()]
        public void SetNawUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "мужчина";

            var controller = new UserController(userName);

            controller.SetNawUserData(gender, birthDate, weight, height);

            var controller2 = new UserController(userName);

            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);

            //правило трех А



        }
    }
}