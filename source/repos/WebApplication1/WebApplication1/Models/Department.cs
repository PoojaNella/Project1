using WebApplication1.Controllers;

namespace WebApplication1.Models
{
    public class Department
    {
       
        public int DeptId { get; set; }
        public String DeptName { get; set; }
        public string DepartmentDescription { get; set; }

        public List<Course> Courses { get; set; }

        public Department(int deptId, string deptName, string departmentDescription,List<Course> courses)
        {
            this.DeptId = deptId;
            this.DeptName = deptName;
            this.DepartmentDescription = departmentDescription;
            this.Courses = courses;
        }

       /* public Department(int deptId, string deptName, string departmentDescription)
        {
            this.DeptId = deptId;
            this.DeptName = deptName;
            this.DepartmentDescription = departmentDescription;
            //this.Courses = courses;
        }*/
    }
}
