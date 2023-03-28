using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class StudentController : Controller
    {
        StudentMoc db = new StudentMoc();
        public IActionResult Index()
        {
            return View(db.GetAllStudents());
            #region Create the ViewResult yourself
            //ViewData.Model = db.GetAllStudents();
            //return new ViewResult() { ViewName = "Index", ViewData = ViewData };
            #endregion
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student newStudent)
        {
            if (ModelState.IsValid)
            {
                db.AddStudent(newStudent);
                return RedirectToAction("Index");
            }
            else return View("Create", newStudent);
        }

        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();
            Student student = db.GetStudentById(id.Value);
            if (student is null) return NotFound();
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();
            Student student = db.GetStudentById(id.Value);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student, int? id)
        {
            if (id is null) return BadRequest();
            student.Id = (int)id;
            db.UpdateStudent(student);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            Student student = db.GetStudentById(id.Value);
            return View(student);
        }
        [HttpPost, ActionName("delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id is null) return BadRequest();
            db.DeleteStudent(id.Value);
            return RedirectToAction("Index");
        }
        public IActionResult CheckEmail(string email, string Name,int Grade)
        {
            if (db.isExists(email) != null) return Json($"You can use email {Name}-{Grade}@iti.gov.eg"); // the email already exists
            else return Json(true);
        }

    }
}

//public IActionResult Create(int id, string Name, int Grade)
//{
//    Student newStudent = new Student() { Id = id, Name = Name, Grade = Grade };
//    db.AddStudent(newStudent);
//    return View("Index", db.GetAllStudents());
//    //return RedirectToAction("Index");
//}