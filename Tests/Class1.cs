using System;
using System.Collections.Generic;
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

        [Test]
        public void Get_Create_Action_Creates_CreationView()
        {
            var homeController = new HomeController();
            var result = homeController.Create() as ViewResult;
            var model = result.Model as BlogEntry;

            Assert.AreEqual(string.Empty, model.Title);
        } 
        
        [Test]
        public void Post_Create_Action_Added_Blog_Entry_To_Blog()
        {
            var homeController = new HomeController();
            var blog = HomeController.currentBlog;

            var model = new BlogEntry(string.Empty);

            Assert.AreEqual(string.Empty, model.Title);

            model.Title = "My Title";
            model.Body = "My Body";

            var result = homeController.Create(model) as ViewResult;

            Assert.That(blog.Entries.Count(), Is.GreaterThan(0));
        }


        [Test]
        public void DefaultView_Should_Return_BlogEntries()
        {
            var homeController = new HomeController();
            homeController.Create(new BlogEntry("My BlogEntry"));
            var result = homeController.Index() as ViewResult;

            var entries = result.Model as IEnumerable<BlogEntry>;
            Assert.That(entries.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void Details_View_Should_Return_Blog_Entry()
        {
            var homeController = new HomeController();

            homeController.Create(new BlogEntry("UniqueTitle"));
            var result = homeController.Detail("UniqueTitle");
            var blogEntry = result.Model as BlogEntry;

            Assert.AreEqual("UniqueTitle", blogEntry.Title);

        }


    }
}
