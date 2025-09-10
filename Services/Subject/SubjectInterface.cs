using APITransacitons.DTOs.Subject;
using APITransacitons.Models;

namespace APITransacitons.Services.SubjectService
{
    public interface SubjectInterface 
    {
        Task<ResponseModel<List<Subject>>> GetAllSubjects();
        Task<ResponseModel<Subject>> GetSubjectById(int id);

        Task<ResponseModel<List<Subject>>> PostSubject(NewSubjectDTO newSubjectDTO);
        Task<ResponseModel<List<Subject>>> Updatesubject(UpdateSubjectDTO updateSubjectDTO);

        Task<ResponseModel<List<Subject>>> Deletesubject(int id);
    }
}
