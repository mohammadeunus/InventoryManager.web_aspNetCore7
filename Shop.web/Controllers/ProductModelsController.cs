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

        public ProductModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductModels
        // GET: /Category/CategoryEntry
        public IActionResult CategoryEntry()
        { 
            return View();
        }
         
        public IActionResult SaveCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                // Set the current time for CreatedDate and UpdatedDate properties
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = "Eunus";

                // Process and save the category data
                _context.categories.Add(model);
                _context.SaveChanges();

                // Redirect to a different page after successful submission
                return RedirectToAction("index");
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
