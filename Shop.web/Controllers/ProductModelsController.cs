﻿using System;
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
            var modList = new List<SelectListItem>();
            foreach (var category in _context.categories)
            {
                modList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            ViewBag.modList = modList;

            return View();
        }

        public IActionResult SaveProduct(ProductModel model)
        {
            try
            {
                _logger.LogInformation("ProductModels/SaveProduct action was called.");

                // Set the current time for CreatedDate and UpdatedDate properties
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = "Eunus";
                 

                if (ModelState.IsValid)
                {
                    
                    // Process and save the Product data
                    _context.products.Add(model);
                    _context.SaveChanges();

                    ModelState.Clear();

                    // Redirect to a different page after successful submission
                    return RedirectToAction("index");
                }
                else
                {
                    _logger.LogInformation("ModelState is not valid: In ProductModels/SaveCategory.");
                    foreach (var keyModelStatePair in ModelState)
                    {
                        var errors = keyModelStatePair.Value.Errors;
                        if (errors != null && errors.Count > 0)
                        {
                            var key = keyModelStatePair.Key;
                            var errorMessageArray = errors.Select(error =>
                            {
                                return error.ErrorMessage;
                            }).ToArray();

                            var errorMessages = string.Join(", ", errorMessageArray);
                            // do something with your keys and errorMessages here
                            _logger.LogInformation($"ModelState is not valid:{key} has {errorMessages}");
                            
                        }
                    }
                }

                // If the model state is not valid, return to the ProductEntry view with validation errors
                return View("ProductEntry", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in ProductModels/SaveProduct");
                // Optionally, you can handle the exception and show an appropriate error message to the user
                return View("Error");
            }
        }

        public IActionResult Index()
        {
            try
            {
                return View(_context.products); //_context.products without it the view won't be able to iterate from the products
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in ProductModels/Index");
                // Optionally, you can handle the exception and show an appropriate error message to the user
                return View("Error");
            }
        }


    }
}
