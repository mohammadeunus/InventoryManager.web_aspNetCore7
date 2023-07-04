 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.web.Data;
using Shop.web.Models;

namespace Shop.web.Controllers
{
    public class ProductModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public ProductModelsController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: ProductModels
        // GET: /Product/ProductEntry
        public IActionResult ProductEntry()
        { 
            return View();
        }
         
        public IActionResult SaveProduct(ProductModel model)
        {
            _logger.LogInformation("ProductModels/SaveProduct action was called.");

            // Set the current time for CreatedDate and UpdatedDate properties
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = "Eunus";
            model.CategoryId = 1;
            ModelState.Clear();


            if (ModelState.IsValid)
            {
                // Process and save the Product data
                _context.products.Add(model);
                _context.SaveChanges();

                // Redirect to a different page after successful submission
                return RedirectToAction("index");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is not Valid: In ProductModels/SaveCategory.");
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        _logger.LogInformation("ModelState is not Valid: "+ error.ErrorMessage); 
                    }
                }
                ModelState.Clear();
            }


            // If the model state is not valid, return to the ProductEntry view with validation errors
            return View("ProductEntry", model);
        }


        public IActionResult index()
        {
            return View(_context.products);
        } 
        
    }
}
