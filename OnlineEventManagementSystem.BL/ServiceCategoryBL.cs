using OnlineEventManagement.DAL.Repository;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagement.DAL.Interface;
using OnlineEventManagementSystem.BL.Interface;
using System.Collections.Generic;
using System;

namespace OnlineEventManagementSystem.BL
{
    public class ServiceCategoryBL : IServiceCategoryBL
    {
        IServiceCategoryRepository categoryRepository;
        public ServiceCategoryBL()
        {
            categoryRepository = new ServiceCategoryRepository();
        }
        public void AddCategory(ServiceCategory category)
        {
            categoryRepository.AddCategory(category);       //Adding new service
        }
        public ServiceCategory GetCategoryById(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);    //Getting a particular service from the database
        }
        public IEnumerable<ServiceCategory> GetCategoryList()
        {
            return categoryRepository.GetCategoryList();         //Getting the services from the database
        }
        public bool VerifyCategory(string categoryName)
        {
            return categoryRepository.VerifyCategory(categoryName);    //Verifying service existance
        }
        public void DeleteCategory(int categoryId)
        {
            categoryRepository.DeleteCategory(categoryId);         //Deleting service from the database
        }
        public void UpdateCategory(ServiceCategory category)
        {
            categoryRepository.UpdateCategory(category);      //Updating the service details in the database
        }

        public int GenerateCategoryID()
        {
            return categoryRepository.GenerateCategoryID();
        }
    }
}
