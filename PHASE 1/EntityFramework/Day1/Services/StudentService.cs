using Day1.Models;
using Day1.Repositories;
using Day1.DTOs;

namespace Day1.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public AddStudentResponse Create(AddStudentRequest createModel)
    {
        var createStudent = new Student
        {
            FirstName = createModel.FirstName,
            LastName = createModel.LastName,
            City = createModel.City,
            State = createModel.State
        };

        var student = _studentRepository.Create(createStudent);

        _studentRepository.SaveChanges();

        return new AddStudentResponse
        {
            Id = student.Id,
            FirstName = student.FirstName
        };
    }

    public bool Delete(int id)
    {
        var deleteStudent = _studentRepository.Get(i => i.Id == id);

        if (deleteStudent != null)
        {
            _studentRepository.Delete(deleteStudent);
            _studentRepository.SaveChanges();

            return true;
        }
        return false;
    }

    public IEnumerable<Student> GetAll()
    {
        var list = _studentRepository.GetAll(i => true);

        return list;
    }

    public StudentViewModel? Update(int id, StudentUpdateModel updateModel)
    {
        var updateStudent = _studentRepository.Get(i => i.Id == id);

        if (updateStudent != null)
        { 
            updateStudent.FirstName = updateModel.FirstName;
            updateStudent.LastName = updateModel.LastName;
            updateStudent.City = updateModel.City;
            updateStudent.State = updateModel.State;

            _studentRepository.Update(updateStudent);
            _studentRepository.SaveChanges();
        }
        return null;
    }
}