using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.web.Data;
using Shop.web.Models;

namespace Shop.web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public CustomerController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: CustomerModels
        // GET: /Customer/CustomerEntry
        public IActionResult CustomerEntry()
        { 
            return View();
        }

        public IActionResult SaveCustomer(CustomerModel model)
        {
            _logger.LogInformation("CustomerModel/SaveCustomer action was called.");

            // Set the current time for CreatedDate and UpdatedDate properties
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = "Eunus";

            ModelState.Clear();
            if (ModelState.IsValid)
            {
                // Process and save the Customer data
                _context.customers.Add(model);
                _context.SaveChanges();

                // Redirect to a different page after successful submission
                return RedirectToAction("index");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is not Valid: In CustomerModel/SaveCustomer.");
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        _logger.LogInformation("ModelState is not Valid: " + error.ErrorMessage);
                    }
                }
                ModelState.Clear();
            }


            // If the model state is not valid, return to the CustomerEntry view with validation errors
            return View("CustomerEntry", model);
        }


        public IActionResult index()
        {
            return View(_context.customers);
        }
    }
}
