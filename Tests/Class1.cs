﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    using System.Collections.ObjectModel;
    using System.Web.Mvc;

    using blogKata.Controllers;

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
    }

    public class Blog
    {

        private ICollection<BlogEntry> _entries = new Collection<BlogEntry>();

        public IEnumerable<BlogEntry> Entries
        {
            get
            {
                return _entries;
            }
            
        }
    }

    public class BlogEntry
    {
    }
}
