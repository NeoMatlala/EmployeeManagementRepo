using EmployeeManagement.Data;
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
    }
}
