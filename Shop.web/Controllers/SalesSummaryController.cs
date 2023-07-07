using Microsoft.AspNetCore.Mvc;
using Shop.web.Models;
using Shop.web.Repositories;
using Shop.web.Repository;

namespace Shop.web.Controllers
{
    public class SalesSummaryController : Controller
    {
        private readonly SalesSummaryRepository _salesSummaryRepository;
        private readonly ILogger<ProductController> _logger;

        public SalesSummaryController(ILogger<ProductController> logger, SalesSummaryRepository salesSummaryRepo)
        {
            _logger = logger;
            _salesSummaryRepository = salesSummaryRepo;
        }
        [HttpGet]
        public IActionResult SalesSummaryEntry()
        {
            ViewBag.modList = _salesSummaryRepository.PopulateFKeyDropDownList();

            return View();
        }

        [HttpPost]
        public IActionResult SalesSummaryEntry(SalesSummaryModel model)
        {
            try
            {
                _logger.LogInformation("Product/SaveProduct action was called.");

                if (ModelState.IsValid)
                {
                    _salesSummaryRepository.AddData(model);
                    ModelState.Clear();

                    // Redirect to a different page after successful submission
                    return RedirectToAction("Index");
                }
                else
                {
                    _salesSummaryRepository.LogValidationErrors(ModelState);

                    // If the model state is not valid, return to the SalesSummaryEntry view with validation errors

                    ViewBag.modList = _salesSummaryRepository.PopulateFKeyDropDownList();
 
                    return View("SalesSummaryEntry", model);
 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in SalesSummary/SalesSummaryEntry[HttpPost]");
                return View("Error");
            }
        }


        public IActionResult Index()
        {
            try
            {
                var sales = _salesSummaryRepository.GetAllData();
                return View(sales);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in SalesSummary/Index");
                return View("Error");
            }
        }
    }
}