﻿namespace SportsStore.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using SportsStore.WebUI.Controllers;
    using SportsStore.WebUI.Models;
    using SportsStore.WebUI.HtmlHelpers;
    using System.Web.Mvc;

    [TestClass]
    public class UnitTest1
    {
        // IProductRepository _repository;
        static ProductController _controller;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            // _repository = GetRepository();
            _controller = GetProductController();
        }

        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            // var controller = GetProductController();

            // Act
            // var result = (IEnumerable<Product>)controller.List(2).Model;
            var result = (ProductsListViewModel)_controller.List(2).Model;

            // Assert
            // var prodArray = result.ToArray();
            var prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange
            // a helper method HTML
            HtmlHelper myHelper = null;
            // creating PagingInfo
            var pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // setting delegate 
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Act
            var result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>" +
                @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" +
                @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            /*
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductId = 1, Name = "P1" },
                new Product { ProductId = 2, Name = "P2" },
                new Product { ProductId = 3, Name = "P3" },
                new Product { ProductId = 4, Name = "P4" },
                new Product { ProductId = 5, Name = "P5" }
            });
            var controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            */
            // var controller = GetProductController();

            // Act
            var result = (ProductsListViewModel)_controller.List(2).Model;

            // Assert
            var pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        static ProductController GetProductController()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] { 
                new Product { ProductId = 1, Name = "P1" },
                new Product { ProductId = 2, Name = "P2" },
                new Product { ProductId = 3, Name = "P3" },
                new Product { ProductId = 4, Name = "P4" },
                new Product { ProductId = 5, Name = "P5" }
            });
            var controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            return controller;
        }
    }
}
