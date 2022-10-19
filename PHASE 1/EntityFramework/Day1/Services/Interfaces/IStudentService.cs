using Day1.DTOs;
using Day1.Models;

namespace Day1.Services;

public interface IStudentService
{
    // IEnumerable<StudentViewModel> GetAll();
    // StudentViewModel? GetById(int id);
    // int? Create(StudentCreateModel createModel);
    // StudentViewModel? Update(int id, StudentUpdateModel updateModel);
    // bool Delete(int id);

    AddStudentResponse Create(AddStudentRequest createModel);
    IEnumerable<Student> GetAll();
    StudentViewModel? Update(int id, StudentUpdateModel updateModel);
    bool Delete(int id);

}