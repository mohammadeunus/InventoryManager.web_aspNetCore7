using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shop.web.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllData();
        void LogValidationErrors(ModelStateDictionary modelState);
        void AddData(T model);
        List<SelectListItem> PopulateFKeyDropDownList();
    }
}
