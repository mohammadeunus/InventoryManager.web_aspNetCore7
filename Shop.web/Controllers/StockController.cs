using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.web.Data;
using Shop.web.Models;

namespace Shop.web.Controllers
{
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public StockController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: StockModels
        // GET: /Stock/StockEntry
        public IActionResult StockEntry()
        {
            var modList = new List<SelectListItem>();
            foreach (var prodItem in _context.products)
            {
                modList.Add(new SelectListItem { Text = prodItem.Name, Value = prodItem.Id.ToString() }); // add product `Name` and it's `Id` from database to modList
            }
            ViewBag.prodList = modList;

            return View();
        }

        public IActionResult SaveStock(StockModel model)
        {
            _logger.LogInformation("StockModel/SaveStock action was called.");

            // Set the current time for CreatedDate and UpdatedDate properties
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = "Eunus";

            ModelState.Clear();
            if (ModelState.IsValid)
            {
                // Process and save the Stock data
                _context.stocks.Add(model);
                _context.SaveChanges();

                // Redirect to a different page after successful submission
                return RedirectToAction("index");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is not Valid: In StockModel/SaveStock.");
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        _logger.LogInformation("ModelState is not Valid: " + error.ErrorMessage);
                    }
                }
                ModelState.Clear();
            }


            // If the model state is not valid, return to the StockEntry view with validation errors
            return View("StockEntry", model);
        }


        public IActionResult index()
        {
            return View(_context.stocks);
        }
    }
}
