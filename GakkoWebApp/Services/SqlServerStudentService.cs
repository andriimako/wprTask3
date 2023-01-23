using GakkoWebApp.Models;
using System.Data.SqlClient;
using GakkoWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace GakkoWebApp.Services
{
    public class SqlServerStudentService : IStudentService
    {
       
        public List<Student> GetStudents(string query)
        {
            SqlConnection con =
                new SqlConnection(
                    "Data Source=localhost,1433;Initial Catalog=master;User ID=SA;Password=<YourStrong@Passw0rd>; TrustServerCertificate=true;");
            SqlCommand com = new SqlCommand();
            com.CommandText = "SELECT * FROM Student";

            com.Connection = con;
            
            con.Open();
            var dr = com.ExecuteReader();
            var students = new List<Student>();
            
            while(dr.Read()) 
            {
                var s = new Student();
                s.FirstName = dr["FirstName"].ToString();
                s.LastName = dr["LastName"].ToString();
                s.IdStudent = int.Parse(dr["IdStudent"].ToString());
                students.Add(s);
            }
            
            if (string.IsNullOrWhiteSpace(query))
            {
                return students;
            }
            
            // ViewBag.Names = names;
            // ViewBag.Title = "Students";
            query = query.ToLower();
            return students.Where(e => e.LastName.ToLower().Contains(query) || e.FirstName.ToLower().Contains(query) || e.IdStudent.ToString().Contains(query)).ToList();
        }

        public void InsertStudent(Student student)
        {
            SqlConnection con =
                new SqlConnection(
                    "Data Source=localhost,1433;Initial Catalog=master;User ID=SA;Password=<YourStrong@Passw0rd>; TrustServerCertificate=true;");
            SqlCommand com = new SqlCommand();
            com.CommandText = "SELECT * FROM Student";

            com.Connection = con;
            
            con.Open();

            //last student ID
            com.CommandText = "SELECT MAX(IdStudent) FROM Student";
            var lastId = (int)com.ExecuteScalar();
            student.IdStudent = lastId + 1;
            
            com.CommandText = "INSERT INTO Student (FirstName, LastName, IdStudent) VALUES (@firstName, @lastName, @IdStudent)";
            
            com.Parameters.AddWithValue("@firstName", student.FirstName);
            com.Parameters.AddWithValue("@lastName", student.LastName);
            com.Parameters.AddWithValue("@IdStudent", student.IdStudent);

            com.Connection = con;
            var dr = com.ExecuteNonQuery();
            con.Close();
        }


      
    }
}
