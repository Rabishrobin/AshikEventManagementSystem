using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ServiceCategoryController : Controller
    {
        [HttpGet]
        public ViewResult DisplayCategories()
        {
            IEnumerable<ServiceCategory> categories = ServiceCategoryBL.DisplayCategory();                        //Getting the categories from the database
            ViewBag.Categories = categories;                                                        //Passing them to the view using view bag
            return View();
        }
        [HttpGet]
        public ViewResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(ServiceCategoryModel newCategory)
        {
            if (ModelState.IsValid)
            {
                int? id = ServiceCategoryBL.VerifyCategory(newCategory.CategoryName);
                bool CanAddCategory = id != null;
                if (CanAddCategory)
                {
                    var category = AutoMapper.Mapper.Map<ServiceCategoryModel, ServiceCategory>(newCategory);      //Automapping category details from model to entity
                    category.CategoryID = ServiceCategory.GenerateCategoryID(id.GetValueOrDefault());
                    ServiceCategoryBL.AddCategory(category);                                                //Adding the category to the database
                    return RedirectToAction("DisplayCategories");                           //Redirecting after adding the category
                }
                TempData["Message"] = "Category already exists";
            }
            return View();
        }
        [HttpGet]
        public ViewResult UpdateCategory(int categoryId)
        {
            ServiceCategory category = ServiceCategoryBL.GetCategoryById(categoryId);                             //Getting the category details from database
            ServiceCategoryModel categoryModel = AutoMapper.Mapper.Map<ServiceCategory, ServiceCategoryModel>(category);    //Mapping the category to the model to show the existing details
            return View(categoryModel);
        }
        [HttpPost]
        public ActionResult UpdateCategory([Bind(Include = "CategoryID, CategoryName")] ServiceCategoryModel categoryModel)
        {
            ServiceCategory category = ServiceCategoryBL.GetCategoryById(categoryModel.CategoryId);           //Getting the objecct of the category by using the category id from the database
            category.CategoryName = categoryModel.CategoryName;                           //Updating the category name if any changes made
            ServiceCategoryBL.UpdateCategory(category);                                          //Updating the database
            TempData["Message"] = "Category updated";
            return View();
        }
        [HttpGet]
        public ViewResult DeleteCategory(int categoryId)
        {
            ServiceCategoryBL.DeleteCategory(categoryId);
            //TempData["Message"] = "Service deleted";
            return View();
        }
    }
}