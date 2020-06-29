using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ch04MovieList.Models;

namespace Ch04MovieList.Areas.Module6.Controllers
{
    [Area("Module6")]
    public class StudentsController : Controller
    {
        public IActionResult Index(int accessLevel)
        {
            StudentViewModel studentView = new StudentViewModel();
            studentView.AccessLevel = accessLevel;
            List<StudentModel> students = new List<StudentModel>();
            StudentModel student1 = new StudentModel("Shelbie", "Simmons", 100);
            StudentModel student2 = new StudentModel("Spencer", "Vorhies", 75);
            StudentModel student3 = new StudentModel("Max", "Sparks", 80);
            StudentModel student4 = new StudentModel("Samantha", "Basar", 50);
            StudentModel student5 = new StudentModel("Abigail", "Schniepp", 50);
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);
            studentView.Students = students;
            return View(studentView);
        }
    }
}
