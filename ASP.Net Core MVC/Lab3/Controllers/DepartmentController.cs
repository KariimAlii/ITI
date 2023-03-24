using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentMoc db = new DepartmentMoc();
        public IActionResult Index()
        {
            return View(db.GetAllDepartments());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            db.CreateDepartment(department);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();
            //Department department = db.GetDepartmentById(id.Value);
            Department department = db.GetDepartmentById((int)id);
            if (department is null) return NotFound();
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();
            Department department = db.GetDepartmentById((int)id);
            if (department is null) return NotFound();
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department, int? id)
        {
            if (id is null) return BadRequest();
            department.Id = (int)id;
            db.UpdateDepartment(department);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            Department department = db.GetDepartmentById((int)id);
            if (department is null) return NotFound();
            return View(department);
        }
        [HttpPost, ActionName("delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id is null) return BadRequest();
            db.DeleteDepartment((int)id);
            return RedirectToAction("Index");
        }
    }
}
