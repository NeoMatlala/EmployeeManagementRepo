using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // READ
        public IActionResult Index()
        {
            var employeeList = _db.Employees.ToList();
            List<int> employeeIds = employeeList.Select(employee => employee.ID).ToList();

            var employees = _db.Departments
            .Where(e => employeeIds.Contains(e.ID)) // Replace EmployeeId with your actual property name
            .Select(e => e.DepartmentName)
            .ToList();


            ViewData["employeeIds"] = "Neo";

            return View(employeeList);
        }

        // CREATE
        public IActionResult Create()
        {
            var viewModel = new DepartmentEmployeeViewModel();

            viewModel.Departments = _db.Departments.ToList();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentEmployeeViewModel viewModel)
        {
            viewModel.Departments = _db.Departments.ToList();

            //if (!ModelState.IsValid)
            //{
            //    return View(viewModel);
            //}

            var newEmployee = new Employee
            {
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                JobTitle = viewModel.JobTitle,
                IDNumber = viewModel.IDNumber,
                DepartmentId = viewModel.DepartmentId,
                DepartmentName = _db.Departments
                .Where(e => e.ID == viewModel.DepartmentId) // Replace EmployeeId with your actual property name
                .Select(e => e.DepartmentName)
                .FirstOrDefault(),
            };

            //var departmentName = _db.Departments
            //.Where(e => e.ID == newEmployee.DepartmentId) // Replace EmployeeId with your actual property name
            //.Select(e => e.DepartmentName)
            //.FirstOrDefault();

            _db.Employees.Add(newEmployee);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // UPDATE
        public IActionResult Update(int? id)
        {
            if(id == null || id== 0)
            {
                return NotFound();
            }
            var employee = _db.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id== 0)
            {
                return NotFound();
            }

            var employee = _db.Employees.Find(id);

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
