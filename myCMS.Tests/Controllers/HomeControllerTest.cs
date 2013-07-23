using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using myCMS;
using myCMS.Controllers;

namespace myCMS.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController(); 

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}





