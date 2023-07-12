using Microsoft.AspNetCore.Mvc;
using Shop.web.Models;
using Shop.web.Repositories;
using Shop.web.Repository;

namespace Shop.web.Controllers
{
    public class SalesDetailsController : Controller
    {
        private readonly SalesDetailsRepository _SalesDetailsRepository;
        private readonly ILogger<ProductController> _logger;

        public SalesDetailsController(ILogger<ProductController> logger, SalesDetailsRepository salesDetailsRepo)
        {
            _logger = logger;
            _SalesDetailsRepository = salesDetailsRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                ViewBag.modList = _SalesDetailsRepository.PopulateFKeyDropDownList();
                return View(_SalesDetailsRepository.GetAllDatas());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in SalesDetails/Index");
                return View("Error");
            }
        }


        [HttpPost]
        public IActionResult Index(SalesViewModel model)
        {
            try
            {
                ModelState.Clear();
                _logger.LogInformation("Product/SaveProduct action was called.");

                if (ModelState.IsValid)
                {
                    _SalesDetailsRepository.AddData(model.SalesDetailsViewModel);
                    ModelState.Clear();

                    // Redirect to a different page after successful submission
                    return RedirectToAction("Index");
                }
                else
                {
                    _SalesDetailsRepository.LogValidationErrors(ModelState);

                    // If the model state is not valid, return to the SalesDetailsEntry view with validation errors

                    ViewBag.modList = _SalesDetailsRepository.PopulateFKeyDropDownList();
 
                    return View("Index", model);
 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in SalesDetails/SalesDetailsEntry[HttpPost]");
                return View("Error");
            }
        }

        
    }
}