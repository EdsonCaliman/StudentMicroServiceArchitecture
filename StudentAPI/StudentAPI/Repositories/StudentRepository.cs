using Dapper;
using Microsoft.Extensions.Configuration;
using StudentAPI.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StudentAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;
        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }

        public Student Add(Student student)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "insert into student (id, name, created_date) values (@id, @name, @created_date)";

            var result = connection.Execute(query, new { id = student.Id, name = student.Name, created_date = student.Created_Date});

            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var studentList = connection.Query<Student>("select id, name, created_date from student");

            return studentList;
        }
    }
}
