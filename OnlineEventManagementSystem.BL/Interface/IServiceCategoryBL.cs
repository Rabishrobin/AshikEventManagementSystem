using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL.Interface
{
    public interface IServiceCategoryBL
    {
        void AddCategory(ServiceCategory category);
        void UpdateCategory(ServiceCategory category);
        void DeleteCategory(int categoryId);
        IEnumerable<ServiceCategory> GetCategoryList();
        ServiceCategory GetCategoryById(int categoryId);
        bool VerifyCategory(string categoryName);
        int GenerateCategoryID();
    }
}
