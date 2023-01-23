using GakkoWebApp.Models;

namespace GakkoWebApp.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents(string query);
        void InsertStudent(Student student);
    }
}
