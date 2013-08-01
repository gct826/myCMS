using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using myCMS.Models;
using myCMS.IoC;
using myCMS.Binders;

namespace myCMS.Tests.Helper
{
    class MockHelper
    {
        public static HttpContext FakeHttpContext()
        {
            var httpRequest = new HttpRequest("", "http://localhost:54498/", "");
            var stringWriter = new StringWriter();
            var httpResponce = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponce);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                    new HttpStaticObjectsCollection(), 10, true,
                                                    HttpCookieMode.AutoDetect,
                                                    SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                        BindingFlags.NonPublic | BindingFlags.Instance,
                                        null, CallingConventions.Standard,
                                        new[] { typeof(HttpSessionStateContainer) },
                                        null)
                                .Invoke(new object[] { sessionContainer });

            return httpContext;
        }

        //public static ControllerContext FakeControllerContext()
        //{
        //    var controllerContext = new ControllerContext(MockHelper.FakeHttpContext(),
        //                    new RouteData(),
        //                    new Mock<ControllerBase>().Object);

        //    return controllerContext;
        //}

        //public static RouteValues FakeRouteValues()
        //{
        //    return new RouteValues
        //        {
        //            Action = "Index",
        //            Controller = "Home",
        //            Language = "en"
        //        };

        //}
    }
}
