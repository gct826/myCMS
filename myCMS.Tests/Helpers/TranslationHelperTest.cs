using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using myCMS.Controllers;
using myCMS.Helpers;
using myCMS.Models;

namespace myCMS.Tests.Helpers
{
    [TestClass]
    class TranslationHelperTest
    {
        [TestMethod]
        public void ValidTranslation()
        {
            //Arrange
            var helper = new TranslationHelper();
            var testCode = "abc";

            //Act
            var result = helper.ValidTranslation(testCode);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
