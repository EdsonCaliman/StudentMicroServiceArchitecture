using StudentAPI.Domain;
using StudentAPI.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace StudentAPI.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly StudentMessageService _studentMessageService;

        public StudentService(IStudentRepository studentRepository, StudentMessageService studentMessageService)
        {
            _studentRepository = studentRepository;
            _studentMessageService = studentMessageService;
        }

        public Student Add(Student student)
        {
            var studentSaved = _studentRepository.Add(student);

            _studentMessageService.SendMessage(student);

            return studentSaved;
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll().ToList();
        }
    }
}
