using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;
using System.Linq;
using OnlineEventManagement.DAL.Interface;
using System;

namespace OnlineEventManagement.DAL.Repository
{
    public class ServiceCategoryRepository :IServiceCategoryRepository
    {
        public void AddCategory(ServiceCategory category)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Categories.Add(category);               //Adding new category to the database
                context.SaveChanges();                          //Updating the database
            }
        }
        public IEnumerable<ServiceCategory> GetCategoryList()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Categories.ToList();               //Returning the list of the categories
            }
        }
        public bool VerifyCategory(string categoryName)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                bool CanAddCategory = false;
                //Verifying the existance of the event
                if (context.Categories.Where(u => u.CategoryName == categoryName).FirstOrDefault() == null)
                {
                    CanAddCategory = true;
                }
                return CanAddCategory;
            }
        }
        public ServiceCategory GetCategoryById(int categoryId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Categories.Where(e => e.CategoryID == categoryId).FirstOrDefault();                  //Getting a category by passing the category id as a parameter
            }
        }
        public void DeleteCategory(int categoryId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                ServiceCategory category = GetCategoryById(categoryId);                                                    //Getting the categroy object to be deleted
                context.Categories.Attach(category);                                                               //Attaching the object to the context
                context.Categories.Remove(category);                                                               //Removing the object from the context
                context.SaveChanges();                                                                          //Updating the database after deleting the category
            }
        }
        public void UpdateCategory(ServiceCategory category)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;        //Updating the category details
                context.SaveChanges();                                                              //Saving the changes
            }
        }

        public int GenerateCategoryID()
        {
            int id = 0;
            int categoryId;
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                //Getting the latest event id
                id = int.Parse(context.Categories.ToList().Last().CategoryID.ToString().Substring(4))+1;
                //Generating event id
                categoryId = int.Parse((int)'T' + DateTime.Now.Year.ToString().Substring(2, 2) + id.ToString().PadLeft(3, '0'));
            }
            return categoryId;
        }
    }
}
