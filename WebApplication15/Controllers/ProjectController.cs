using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectContext ORM = null;
        public ProjectController(ProjectContext ORM)
        {
            this.ORM = ORM;
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student S)
        {
            ORM.Add(S);
            ORM.SaveChanges();
            ViewBag.Message = "Registration Done Successfully";
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult AllStudents()
        {
            IList<Student> AllStudents = ORM.Student.ToList<Student>();
            return View(AllStudents);
        }

        [HttpPost]
        public IActionResult AllStudents(string SearchByName, string SearchByClass, string SearchBySubject, string SearchByRollNo,
           String SearchByPhoneNum, string SearchByFatherName, string SearchByAddress, string SearchByEmail)

        {   IList<Student> AllStudents = ORM.Student.Where(m => m.Name.Contains(SearchByName) || m.Class.Contains(SearchByClass) || m.Subject.Contains(SearchBySubject) || m.RollNo.Contains(SearchByRollNo) || m.PhoneNum.Equals(SearchByPhoneNum) || m.FatherName.Contains(SearchByFatherName) || m.Address.Contains(SearchByAddress) || m.Email.Contains(SearchByEmail)).ToList<Student>();
            return View(AllStudents);
        }


        public IActionResult StudentDetail(int Id)
        {
            Student S = ORM.Student.Where(m => m.Id == Id).FirstOrDefault<Student>();
            return View(S);
        }


        public IActionResult DeleteStudent(Student S)
        {
            // Student S =  ORM.Student.Where(a => a.Id == Id).FirstOrDefault<Student>();
            ORM.Student.Remove(S);
            ORM.SaveChanges();
            ViewBag.Message = "Delete Done Successfully";
            ModelState.Clear();
            //return View("AllStudents");

            return RedirectToAction("AllStudents");
        }

        [HttpGet]
        public IActionResult EditStudent(int Id)
        {

            Student S = ORM.Student.Where(m => m.Id == Id).FirstOrDefault<Student>();
            return View(S);
        }
        [HttpPost]
        public IActionResult EditStudent(Student S)
        {
            ORM.Student.Update(S);
            ORM.SaveChanges();
            //Student S = ORM.Student.Where(m => m.Id == Id).FirstOrDefault<Student>();
            return RedirectToAction("AllStudents");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}