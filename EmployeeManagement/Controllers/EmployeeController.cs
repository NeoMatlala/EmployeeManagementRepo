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

            var viewModel = new DepartmentEmployeeViewModel();
            viewModel.Employees = _db.Employees.ToList();

            return View(viewModel);
        }

        //CREATE
        public IActionResult Create()
        {
            var viewModel = new DepartmentEmployeeCreateViewModel();


            viewModel.Departments = _db.Departments.ToList();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentEmployeeCreateViewModel viewModel)
        {
            viewModel.Departments = _db.Departments.ToList();

            var newEmployee = new Employee
            {
                Name = viewModel.Employee.Name,
                Surname = viewModel.Employee.Surname,
                JobTitle = viewModel.Employee.JobTitle,
                IDNumber = viewModel.Employee.IDNumber,
                DepartmentId = viewModel.Employee.DepartmentId,
                DepartmentName = _db.Departments
                .Where(e => e.ID == viewModel.Employee.DepartmentId)
                .Select(e => e.DepartmentName)
                .FirstOrDefault(),
            };

            _db.Employees.Add(newEmployee);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        // UPDATE
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var viewModel = new DepartmentEmployeeCreateViewModel();
            viewModel.Departments = _db.Departments.ToList();

            viewModel.Employee = _db.Employees.Find(id);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(DepartmentEmployeeCreateViewModel viewModel)
        {

            var userId = viewModel.Employee.ID;
            viewModel.Departments = _db.Departments.ToList();

            // Fetch the existing employee from the database
            var existingEmployee = _db.Employees.Find(userId);

            existingEmployee.Name = viewModel.Employee.Name;
            existingEmployee.Surname = viewModel.Employee.Surname;
            existingEmployee.JobTitle = viewModel.Employee.JobTitle;
            existingEmployee.IDNumber = viewModel.Employee.IDNumber;
            existingEmployee.DepartmentId = viewModel.Employee.DepartmentId;
            existingEmployee.DepartmentName = _db.Departments
            .Where(e => e.ID == viewModel.Employee.DepartmentId)
            .Select(e => e.DepartmentName)
            .FirstOrDefault();

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var viewModel = new DepartmentEmployeeCreateViewModel();
            viewModel.Departments = _db.Departments.ToList();

            viewModel.Employee = _db.Employees.Find(id);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee(DepartmentEmployeeCreateViewModel viewModel)
        {
            if (viewModel.Employee.ID == null || viewModel.Employee.ID == 0)
            {
                return NotFound();
            }

            var employee = _db.Employees.Find(viewModel.Employee.ID);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
