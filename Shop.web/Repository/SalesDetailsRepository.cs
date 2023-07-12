using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.web.Data;
using Shop.web.Interfaces;
using Shop.web.Models;

namespace Shop.web.Repository
{
    public class SalesDetailsRepository : IRepository<SalesDetailsModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SalesDetailsRepository> _logger;

        public SalesDetailsRepository(ApplicationDbContext context, ILogger<SalesDetailsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddData(SalesDetailsModel model)
        {
            try
            {
                // Set the current time for CreatedDate and UpdatedDate properties
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = "Eunus";

                _context.salesDetails.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SalesDetailsRepository.AddData: An error occurred while saving the product.");
                throw;
            }
        }

        public IEnumerable<SalesDetailsModel> GetAllData()
        {
            throw new NotImplementedException();
        }

        public SalesViewModel GetAllDatas()
        {
            try
            {
                var saleDetailsView = new SalesViewModel()
                {
                    saleDetailsListViewModel = _context.salesDetails.ToList(),
                    stockModel = _context.stocks.FirstOrDefault(), // Assign the first stock model from the context
                    SalesDetailsViewModel = _context.salesDetails.FirstOrDefault(),
                };
                return saleDetailsView;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SalesDetailsRepository.GetAllData: An error occurred while retrieving products.");
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

        public List<SelectListItem> PopulateFKeyDropDownList()
        {
            try
            {
                var modList = new List<SelectListItem>();
                foreach (var customer in _context.products)
                {
                    modList.Add(new SelectListItem { Text = customer.Name, Value = customer.Id.ToString() });
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
