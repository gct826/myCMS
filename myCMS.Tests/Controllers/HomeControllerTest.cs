using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using myCMS.Controllers;
using myCMS.Helpers;
using myCMS.Models;
using myCMS.Tests.Helper;

namespace myCMS.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]

        public void Index()
        {
            // Arrange
            var controller = new HomeController(new RouteService());

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("myCMS", result.ViewBag.Title);
        }

        [TestMethod]
        public void DefaultTranslation()
        {
            // Arrange
            var controller = new HomeController(new RouteService());
            

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("en", result.ViewBag.langRV);
        }
    }
}





