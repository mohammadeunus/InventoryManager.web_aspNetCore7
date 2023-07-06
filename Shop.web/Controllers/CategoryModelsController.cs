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
    public class CategoryModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public CategoryModelsController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: CategoryModels
        // GET: /Category/CategoryEntry
        public IActionResult CategoryEntry()
        { 
            return View();
        }
         
        public IActionResult SaveCategory(CategoryModel model)
        {
            _logger.LogInformation("CategoryModels/SaveCategory action was called.");

            // Set the current time for CreatedDate and UpdatedDate properties
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = "Eunus";
             
            if (ModelState.IsValid)
            { 
                // Process and save the category data
                _context.categories.Add(model);
                _context.SaveChanges();

                // Redirect to a different page after successful submission
                return RedirectToAction("index");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is not Valid: In CategoryModel/SaveCategory.");
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        _logger.LogInformation("ModelState is not Valid: "+ error.ErrorMessage); 
                    }
                }
                ModelState.Clear();
            }


            // If the model state is not valid, return to the CategoryEntry view with validation errors
            return View("CategoryEntry", model);
        }


        public IActionResult index()
        {
            return View(_context.categories);
        } 
        
    }
}
