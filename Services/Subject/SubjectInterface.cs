using APITransacitons.Models;

namespace APITransacitons.Services.SubjectService
{
    public interface SubjectInterface 
    {
        Task<ResponseModel<List<Subject>>> GetAllSubjects();
        Task<ResponseModel<Subject>> GetSubjectById(int id);
        
    }
}
