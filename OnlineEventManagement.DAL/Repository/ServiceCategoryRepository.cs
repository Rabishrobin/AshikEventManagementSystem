using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;
using System.Linq;
using OnlineEventManagement.DAL.Interface;

namespace OnlineEventManagement.DAL.Repository
{
    public class ServiceCategoryRepository :IElementRepository
    {
        public void AddElement(object category)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Categories.Add((ServiceCategory)category);               //Adding new category to the database
                context.SaveChanges();                          //Updating the database
            }
        }
        public IEnumerable<object> DisplayElements()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Categories.ToList();               //Returning the list of the categories
            }
        }
        public int? VerifyExistance(string categoryName)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                int? id = null;
                if (context.Categories.Where(u => u.CategoryName == categoryName).FirstOrDefault() == null)                   //Verifying category existance
                {
                    IEnumerable<ServiceCategory> categories = context.Categories.ToList();
                    id = categories.Count() == 0 ? 0 : int.Parse(categories.Last().CategoryID.ToString().Substring(4)) + 1;
                }
                return id;
            }
        }
        public object GetElementById(int categoryId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Categories.Where(e => e.CategoryID == categoryId).FirstOrDefault();                  //Getting a category by passing the category id as a parameter
            }
        }
        public void DeleteElement(int categoryId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                ServiceCategory category = (ServiceCategory)GetElementById(categoryId);                                                    //Getting the categroy object to be deleted
                context.Categories.Attach(category);                                                               //Attaching the object to the context
                context.Categories.Remove(category);                                                               //Removing the object from the context
                context.SaveChanges();                                                                          //Updating the database after deleting the category
            }
        }
        public void UpdateElement(object category)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Entry((ServiceCategory)category).State = System.Data.Entity.EntityState.Modified;        //Updating the category details
                context.SaveChanges();                                                              //Saving the changes
            }
        }
    }
}
