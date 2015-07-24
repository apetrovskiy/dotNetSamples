namespace SportsStore.WebUI.Controllers
{
    using SportsStore.Domain.Abstract;
    using SportsStore.WebUI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ProductController : Controller
    {
        IProductRepository _repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        // public ViewResult List()
        public ViewResult List(int page = 1)
        {
            // return View(_repository.Products);
            /*
            return View(_repository.Products
                        .OrderBy(p => p.ProductId)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize));
            */
            var model = new ProductsListViewModel
            {
                Products = _repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Products.Count()
                }
            };
            return View(model);
        }
    }
}