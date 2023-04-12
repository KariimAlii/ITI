using Lab3.Models;
using Lab3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lab3.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        //DepartmentMoc db = new DepartmentMoc(); // DepartmentDB db = new DepartmentDB();
        IDepartment db;
        ITIContext context;
        public DepartmentController(IDepartment _db, ITIContext context)
        {
            db = _db;
            this.context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(db.GetAllDepartments());
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
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
        public IActionResult UpdateCourses(int id)
        {
            var dept = context.Departments.Include(d => d.Courses).FirstOrDefault(d => d.Id == id);
            var allCourses = context.Courses.ToList();
            var coursesInDept = dept.Courses.ToList();
            var coursesNotInDept = allCourses.Except(coursesInDept).ToList();
            ViewBag.coursesInDept = new SelectList( coursesInDept , "Crs_Id" , "Crs_Name" );
            ViewBag.coursesNotInDept = new SelectList( coursesNotInDept , "Crs_Id" , "Crs_Name" );
            ViewBag.deptId = dept.Id;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCourses(int id , int[] coursesToRemove, int[] coursesToAdd)
        {
            var dept = context.Departments.Include(d => d.Courses).FirstOrDefault(d => d.Id == id);
            foreach (var item in coursesToRemove)
            {
                var course = dept.Courses.FirstOrDefault(c => c.Crs_Id == item);
                //var course = context.Courses.FirstOrDefault(c => c.Crs_Id == item);
                if (course != null)
                {
                    dept.Courses.Remove(course);
                }
            }
            foreach (var item in coursesToAdd)
            {
                //var course = context.Courses.FirstOrDefault(c => c.Crs_Id == item);
                var course = context.Courses.Find(item);
                if (course != null)
                {
                    dept.Courses.Add(course);
                }
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ShowCourses(int id)
        {
            var department = context.Departments.Include(d => d.Courses).FirstOrDefault(d => d.Id == id);
            return View(department);
        }
        public IActionResult UpdateStudentDegree(int id, int crsId)
        {
            //var students = context.Students.Select(s => s).Where(s => s.DepartmentId == id);
            var students = context.Students.Where(s => s.DepartmentId == id).ToList();
            var course = context.Courses.Find(crsId);
            ViewBag.course = course;
            return View(students);
        }
        [HttpPost]
        public IActionResult UpdateStudentDegree(int id, int crsId, Dictionary<int,int> stdDegree)
        {
            foreach (var item in stdDegree)
            {
                var record = context.StudentCourses.FirstOrDefault(s => s.Course_Id == crsId && s.Student_Id == item.Key);
                if (record == null)
                {
                    StudentCourse stdCrs = new StudentCourse()
                    {
                        Course_Id = crsId,
                        Student_Id = item.Key,
                        Grade = item.Value,
                    };
                    context.StudentCourses.Add(stdCrs);
                }
                else
                {
                    record.Grade = item.Value;
                }
            }
            context.SaveChanges();
            //return RedirectToAction(nameof(UpdateStudentDegree), new { id = id, crsId = crsId });
            return RedirectToAction(nameof(Index));
        }
    }
}



//[HttpPost]
//public IActionResult UpdateStudentDegree(int crsId, int stdId, int grade)
//{
//    var student = context.Students.Find(stdId);
//    var course = context.Courses.Find(crsId);
//    StudentCourse stdCrs = new StudentCourse()
//    {
//        Course_Id = crsId,
//        Student_Id = stdId,
//        Grade = grade,
//        Student = student,
//        Course = course
//    };
//    context.StudentCourses.Add(stdCrs);
//    context.SaveChanges();
//    return RedirectToAction(nameof(Index));
//}