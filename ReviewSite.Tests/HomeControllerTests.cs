using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ReviewsSite;
using ReviewsSite.Controllers;
using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ReviewSite.Tests
{
    public class HomeControllerTests
    {

        IReviewRepository reviewRepo;
        HomeController underTest;

        public HomeControllerTests()
        {
            reviewRepo = Substitute.For<IReviewRepository>();
            underTest = new HomeController(reviewRepo);
        }

        [Fact]
        public void Index_Returns_A_VIew()
        {
             var result = underTest.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Gets_All_Reviews()
        {
            underTest.Index();

            reviewRepo.Received().GetAll();
        }

        [Fact]
        public void Index_Sets_AllReviews_As_Model()
        {
            var expectedModel = new List<Review>();
            reviewRepo.GetAll().Returns(expectedModel);

            var result = underTest.Index();

            var model = result.Model;
            Assert.Equal(expectedModel, model);
        }

        [Fact]
        public void Details_Returns_A_View()
        {
            var result = underTest.Details(1);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Details_Sets_Dog_To_Model()
        {
            var expectedModel = new Review();
            reviewRepo.GetById(1).Returns(expectedModel);

            var result = underTest.Details(1);

            var model = result.Model;
            Assert.Equal(expectedModel, model);
        }
    }
}
