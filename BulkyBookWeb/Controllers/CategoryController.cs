using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext db)  //this db will have all the implementation of connect strings and tables that are needed to reterive the data. so we will populate our local db object
        {
            _context = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCatList = _context.Categories;
            return View(objCatList);

        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken] //to help and prevent the cross site request forgery attack
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["NotificationMessage"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //to help and prevent the cross site request forgery attack
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["NotificationMessage"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(category);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int? id) 
        {
            var obj = _context.Categories.Find(id);
            if (obj == null)
            {
                NotFound();
            }
            _context.Categories.Remove(obj);
            _context.SaveChanges();
            TempData["NotificationMessage"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
