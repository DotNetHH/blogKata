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

        [Test]
        public void BlogEntry_TimeStamp_Is_Bigger_Then_Default()
        {
            var blogEntry = new BlogEntry(string.Empty);

            Assert.That(blogEntry.CreatedAt,Is.GreaterThan(default(DateTime)));
        }        
        
        [Test]
        public void BlogEntry_is_Added_to_Blog()
        {
            var blogEntry = new BlogEntry(string.Empty);
            var blog = new Blog();
            blog.Add(blogEntry);
            Assert.AreEqual(1, blog.Entries.Count());
        }

        //[Test]
        //public void Post_Create_Action_Added_Blog_Entry_To_Blog()
        //{
        //    var homeController = new HomeController();
        //    var result = homeController.Index() as ViewResult;
        //    Assert.AreEqual(string.Empty, result.ViewName);
        //}


    }
}
