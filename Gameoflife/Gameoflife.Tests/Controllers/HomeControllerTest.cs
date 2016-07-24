using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gameoflife;
using Gameoflife.Controllers;

namespace Gameoflife.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Templates()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Templates() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Active()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Active() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
