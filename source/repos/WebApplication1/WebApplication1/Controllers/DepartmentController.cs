using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult AdoTest()
        {
            CustomerModel customer = new CustomerModel();   
            DataSet dataSet = new DataSet();
            dataSet = customer.getCustomers();

            return View();
        }

        [HttpPost]
        public IActionResult Index(int CourseID, String CourseName,String CourseDescription)
        {
            Course c = new Course { CourseId= CourseID, CourseName= CourseName,CourseDescription= CourseDescription };

           // ViewBag.CourseInfo = c;
            return View(c);
        }

        public IActionResult testPartial()

        {
            Course c1 = new Course(1,"desc","testCourse");
            return View(c1);  
        }


        
        public IActionResult DepartmentHome()
        {
           

            Course AdvAlgo = new Course(5600, "Advance Algorithms", "Learnings of Algorithms and their implementation to improve performance");
            Course dbSystems = new Course(5470, "Dabase systems", "Learnings of various database systems and how to access them");
            Course compilerDesign = new Course(6300, "Compiler Design", "Translation mechanism and error detection & recovery");
            Course AdvOs = new Course(6900, "Advance operating system", "Addrtesses broad range of topics in Operating system");



           
            List<Course> coursesInCS = new List<Course>();
            coursesInCS.Add(AdvAlgo);
            coursesInCS.Add(dbSystems);
            ViewBag.CScourse = coursesInCS;

            List<Course> coursesInCIS = new List<Course>();
            coursesInCIS.Add(compilerDesign);
            coursesInCIS.Add(AdvOs);

            Department CS = new Department(5000, "Computer Science", "Focuses more on the theory and mathematics behind the technology",coursesInCS);
            Department CIS = new Department(6000, "Computer Information Systems", "This department focuses on practical applictions of technology such as building apps, providing security and designing games", coursesInCIS);
            List<Department> departments = new List<Department>();
            departments.Add(CS);
            departments.Add(CIS);

            ViewBag.cs = CS;

           /* ViewBag.csdepartmentId = "Department Id: "+CS.DeptId;
            ViewBag.csdepartmentName = "Department Name: " + CS.DeptName;
            ViewBag.csdepartmentDescription = "Department Description: " + CS.DepartmentDescription;*/

            ViewBag.cisdepartmentId = "Department Id: " + CIS.DeptId;
            ViewBag.cisdepartmentName = "Department Name: " + CIS.DeptName;
            ViewBag.cisdepartmentDescription = "Department Description: " + CIS.DepartmentDescription;
            return View(departments);
        }

    }

    
}
