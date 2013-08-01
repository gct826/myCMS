using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web;

namespace myCMS.Tests
{
    
    /// <summary>
    ///This is a test class for _DefaultTest and is intended
    ///to contain all _DefaultTest Unit Tests
    ///</summary>

    [TestClass()]
    public class _DefaultTest
    {

        private TestContext testContextInstance;

        [TestInitialize]
        public void TestInit()
        {
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://localhost", ""), new HttpResponse(new System.IO.StringWriter()));
            System.Web.SessionState.SessionStateUtility.AddHttpSessionStateToContext(
            HttpContext.Current, new HttpSessionStateContainer("",
            new SessionStateItemCollection(), new HttpStaticObjectsCollection(), 20000, true,
             HttpCookieMode.UseCookies, SessionStateMode.Off, false));

            //Initialize your specific application custom Context Class.
            //Initialize User object initialized
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Page_Load
        ///</summary>
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("d:\\Rajaraman\\JQuery\\SampleProject", "/")]
        [UrlToTest("http://localhost")]
        [DeploymentItem("SampleProject.dll")]
        public void Page_LoadTest()
        {
            _Default_Accessor target = new _Default_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Page_Load(sender, e);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }


        /// <summary>
        ///A test for SetSession
        ///</summary>
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/SampleProject")]
        [DeploymentItem("SampleProject.dll")]
        public void SetSessionTest()
        {
            _Default_Accessor target = new _Default_Accessor(); // TODO: Initialize to an appropriate value
            target.SetSession();
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetSession
        ///</summary>
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SampleProject")]
        [DeploymentItem("SampleProject.dll")]
        public void SetSessionTest1()
        {
            _Default_Accessor target = new _Default_Accessor(); // TODO: Initialize to an appropriate value
            target.SetSession();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
