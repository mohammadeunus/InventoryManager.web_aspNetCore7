using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Shop.web.Data;
using Shop.web.Models;

namespace Shop.web.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ApplicationDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            try
            {
                return _context.products.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductRepository.GetAllProducts: An error occurred while retrieving products.");
                throw;
            }
        }

        public void LogValidationErrors(ModelStateDictionary modelState)
        {
            try
            {
                _logger.LogInformation("ModelState is not valid: In ProductRepository/LogValidationErrors.");
                foreach (var keyModelStatePair in modelState)
                {
                    var errors = keyModelStatePair.Value.Errors;
                    if (errors != null && errors.Count > 0)
                    {
                        var key = keyModelStatePair.Key;
                        var errorMessageArray = errors.Select(error => error.ErrorMessage).ToArray();

                        var errorMessages = string.Join(", ", errorMessageArray);
                        _logger.LogInformation($"ModelState is not valid: {key} has {errorMessages}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging validation errors.");
                throw;
            }
        }

        public void AddProduct(ProductModel model)
        {
            try
            {
                // Set the current time for CreatedDate and UpdatedDate properties
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = "Eunus";

                _context.products.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductRepository.AddProduct: An error occurred while saving the product.");
                throw;
            }
        }

        public List<SelectListItem> PopulateCategoryListForDropDown()
        {
            try
            {
                var modList = new List<SelectListItem>();
                foreach (var category in _context.categories)
                {
                    modList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
                }
                return modList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductRepository.PopulateCategoryList: An error occurred while populating the category list.");
                throw;
            }
        }
    }
}
