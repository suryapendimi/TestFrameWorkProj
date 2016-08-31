using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using MVCTest.Controllers;
using MVCTest.Domain;
using MVCTest.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MVCTest.Test1.UnitTests.Web.Controllers
{
    [TestFixture]
    public class HomeControllerSpecs
    {
        [Test]
        public void index_action_returns_a_view_result()
        {
            var mock = new Mock<ICurrentUser>();
            var sut=new HomeController(mock.Object);
            var result = sut.Index();
            Assert.That(result,Is.TypeOf<ViewResult>());
        }

        [Test]
        public void index_action_says_a_hello_world()
        {
            var mock = new Mock<ICurrentUser>();
            mock.Setup(u => u.UserName).Returns("John Smith");

            var sut = new HomeController(mock.Object);
            var result = sut.Index();
            Assert.That(sut.ViewBag.Message, Is.EqualTo("Hello John Smith! "));
        }

        [Test]
        public void say_Hello_action_says_hello_to_the_specified_user()
        {
            var mock = new Mock<ICurrentUser>();
            var sut = new HomeController(mock.Object);
            var result = sut.SayHello("John Plunker");

            Assert.That(result,Is.TypeOf<ViewResult>());
            Assert.That(((ViewResult) result).Model, Is.TypeOf<SayHelloViewModel>());
            Assert.That(((SayHelloViewModel) ((ViewResult) result).Model).Name,
                Is.EqualTo("John Plunker"));

        }

        [Test]
        public void say_hello_post_action_redirects_for_the_specified_user()
        {
            var mock = new Mock<ICurrentUser>();
            var sut=new HomeController(mock.Object);
            var result = sut.SayHello(new SayHelloForm {Name = "John Papa"});

            Assert.That(result,Is.TypeOf<RedirectToRouteResult>());

            var routeResult = (RedirectToRouteResult) result;

            Assert.That(routeResult.RouteValues["action"], Is.EqualTo("SayHello"));
            Assert.That(routeResult.RouteValues["name"], Is.EqualTo("John Papa"));
            
        }

        [Test]
        public void setting_name_changes_the_name_of_the_current_user()
        {
            var mock = new Mock<ICurrentUser>();
            var sut=new HomeController(mock.Object);
            var result = sut.SetName("Surya Haaa");

            mock.Verify((x=>x.SetName(("Surya Haaa"))));

            Assert.That(result, Is.TypeOf<RedirectToRouteResult>());

            var routeResult = (RedirectToRouteResult)result;

            Assert.That(routeResult.RouteValues["action"], Is.EqualTo("Index"));
        }

        [Test]
        public void trying_to_set_an_empty_name_fails()
        {
            var mock = new Mock<ICurrentUser>();
            var sut=new HomeController(mock.Object);

            var result=sut.SetName(null);

            mock.Verify(x => x.SetName(It.IsAny<string>()),Times.Never());

           Assert.That(result,Is.TypeOf<ViewResult>());

        }

    }
}
