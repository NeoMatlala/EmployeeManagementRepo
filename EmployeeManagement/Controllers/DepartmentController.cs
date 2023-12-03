using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        //READ
        public IActionResult Index()
        {
            var departments = _db.Departments.ToList();
            return View(departments);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department obj)
        {
            _db.Departments.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            //if (ModelState.IsValid)
            //{
            //    _db.Departments.Add(obj);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(obj);
        }

        // UPDATE
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var department = _db.Departments.Find(id);
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Department obj)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var department = _db.Departments.Find(id);
            return View(department);
        }

        public IActionResult DeleteDepartment(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var department = _db.Departments.Find(id);
            _db.Departments.Remove(department);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
