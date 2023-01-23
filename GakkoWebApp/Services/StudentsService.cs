using GakkoWebApp.Models;

namespace GakkoWebApp.Services
{
    public class StudentsService : IStudentService
    {
        private static List<Student> _students = new List<Student>();
        
        static StudentsService()
        {
            _students = new List<Student>();
            _students.Add(new Student
            {
                IdStudent = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                // Email = "kowalski@wp.pl",
                // Address = "Warsaw, Zlota 12",
                // IndexNumber = "s1234"
            });
            _students.Add(new Student
            {
                IdStudent = 2,
                FirstName = "Anna",
                LastName = "Malewska",
                // Email = "malewska@wp.pl",
                // Address = "Warsaw, Zlota 33",
                // IndexNumber = "s5432"
            });
        }
        
        public List<Student> GetStudents(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return _students;
            }

            return _students.Where(e => e.LastName == query).ToList();
        }

        public void InsertStudent(Student student)
        {
            _students.Add(student);
        }
    }
}
