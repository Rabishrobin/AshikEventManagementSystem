using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.BL.Interface;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ServiceCategoryController : Controller
    {
        IServiceCategoryBL categoryDetails;
        public ServiceCategoryController()
        {
            categoryDetails = new ServiceCategoryBL();
        }

        [HttpGet]
        public ViewResult DisplayCategories()
        {
            IEnumerable<ServiceCategory> categories = categoryDetails.GetCategoryList();                        //Getting the categories from the database
            ViewBag.Categories = categories;                                                        //Passing them to the view using view bag
            return View();
        }

        [HttpGet]
        public ViewResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(ServiceCategoryModel newCategory)
        {
            if (ModelState.IsValid)
            {
                bool CanAddCategory = categoryDetails.VerifyCategory(newCategory.CategoryName);
                if (CanAddCategory)
                {
                    var category = AutoMapper.Mapper.Map<ServiceCategoryModel, ServiceCategory>(newCategory);      //Automapping category details from model to entity
                    categoryDetails.AddCategory(category);                                                //Adding the category to the database
                    return RedirectToAction("DisplayCategories");                           //Redirecting after adding the category
                }
                TempData["Message"] = "Category already exists!!";
            }
            return View();
        }

        [HttpGet]
        public ViewResult UpdateCategory(int id)
        {
            ServiceCategory category = categoryDetails.GetCategoryById(id);                             //Getting the category details from database
            ServiceCategoryModel categoryModel = AutoMapper.Mapper.Map<ServiceCategory, ServiceCategoryModel>(category);    //Mapping the category to the model to show the existing details
            return View(categoryModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCategory([Bind(Include = "CategoryID, CategoryName")] ServiceCategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                ServiceCategory category = (ServiceCategory)categoryDetails.GetCategoryById(categoryModel.CategoryId);           //Getting the objecct of the category by using the category id from the database
                category.CategoryName = categoryModel.CategoryName;                           //Updating the category name if any changes made
                categoryDetails.UpdateCategory(category);                                          //Updating the database
                TempData["Message"] = "Category updated successfully!!";
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            categoryDetails.DeleteCategory(id);
            return RedirectToAction("DisplayCategories");
        }
    }
}