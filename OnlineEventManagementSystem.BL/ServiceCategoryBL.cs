using OnlineEventManagement.DAL.Repository;
using OnlineEventManagement.DAL.Interface;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL
{
    public class ServiceCategoryBL
    {
        static IElementRepository categoryRepository;
        static ServiceCategoryBL()
        {
            categoryRepository = new ServiceCategoryRepository();
        }
        public static void AddCategory(ServiceCategory category)
        {
            categoryRepository.AddElement(category);       //Adding new service
        }
        public static ServiceCategory GetCategoryById(int categoryId)
        {
            return (ServiceCategory)categoryRepository.GetElementById(categoryId);    //Getting a particular service from the database
        }
        public static IEnumerable<ServiceCategory> DisplayCategory()
        {
            return (IEnumerable<ServiceCategory>)categoryRepository.DisplayElements();         //Getting the services from the database
        }
        public static int? VerifyCategory(string categoryName)
        {
            return categoryRepository.VerifyExistance(categoryName);    //Verifying service existance
        }
        public static void DeleteCategory(int categoryId)
        {
            categoryRepository.DeleteElement(categoryId);         //Deleting service from the database
        }
        public static void UpdateCategory(ServiceCategory category)
        {
            categoryRepository.UpdateElement(category);      //Updating the service details in the database
        }
    }
}
