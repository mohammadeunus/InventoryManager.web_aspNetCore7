using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Shop.web.Models;
using Shop.web.Repositories;

namespace Shop.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        // GET: Product
        // GET: /Product/ProductEntry
        public IActionResult ProductEntry()
        {
            ViewBag.modList = _productRepository.PopulateCategoryListForDropDown();

            return View();
        }


        public IActionResult SaveProduct(ProductModel model)
        {
            try
            {
                _logger.LogInformation("Product/SaveProduct action was called.");

                if (ModelState.IsValid)
                {
                    _productRepository.AddProduct(model);
                    ModelState.Clear();

                    // Redirect to a different page after successful submission
                    return RedirectToAction("Index");
                }
                else
                {
                    _productRepository.LogValidationErrors(ModelState);

                    // If the model state is not valid, return to the ProductEntry view with validation errors

                    ViewBag.modList = _productRepository.PopulateCategoryListForDropDown();

                    return View("ProductEntry", model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in Product/SaveProduct"); 
                return View("Error");
            }
        }


        public IActionResult Index()
        {
            try
            {
                var products = _productRepository.GetAllProducts();
                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in Product/Index"); 
                return View("Error");
            }
        }
    }
}
