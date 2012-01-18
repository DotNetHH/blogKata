using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    using System.Web.Mvc;

    using blogKata.Controllers;
    using blogKata.Models;

    [TestFixture]
    public class Class1
    {

        [Test]
        public void WelcomeMessage()
        {
            var homeController = new HomeController();
            var result = homeController.Index() as ViewResult;
            Assert.AreEqual("Welcome to my blog", result.ViewBag.Title);

        }
        
        [Test]
        public void Index_Action_Should_Return_Index_View()
        {
            var homeController = new HomeController();
            var result = homeController.Index() as ViewResult;
            Assert.AreEqual(string.Empty, result.ViewName);

        }


        [Test]
        public void Blog_Entry_Count_Is_Zero_On_Startup()
        {
            var blog = new Blog();
            Assert.AreEqual(0, blog.Entries.Count());
        }

        [Test]
        public void BlogEntry_Title_Is_Provided_Title_On_Creation()
        {
            var blogEntry = new BlogEntry(string.Empty);

            Assert.AreEqual(string.Empty, blogEntry.Title);
        }
        
        [Test]
        public void BlogEntry_Body_Is_Empty_On_Creation()
        {
            var blogEntry = new BlogEntry(string.Empty);

            Assert.AreEqual(string.Empty, blogEntry.Body);
        }
    }
}
