namespace WebApplication1.Models
{
    public class Course
    {
        public Course(int courseId, string courseName, string courseDescription)
        {
            CourseId = courseId;
            CourseName = courseName;
            CourseDescription = courseDescription;
        }

        public Course()
        {

        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }

    }
}
