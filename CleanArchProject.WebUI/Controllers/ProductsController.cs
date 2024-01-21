﻿using CleanArchProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchProject.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
                _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
    }
}
