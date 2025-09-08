using APITransacitons.Models;
using APITransacitons.Services.SubjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITransacitons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectInterface _subjectInterface;
        public SubjectController(SubjectInterface subjectInterface)
        {
            _subjectInterface = subjectInterface;
        }

        [HttpGet("GetAllSubjects")]
        public async Task<ActionResult<ResponseModel<List<Subject>>>> GetAllSubjects()
        {
            var subjects = await _subjectInterface.GetAllSubjects();
            return Ok(subjects);
        }

        [HttpGet("GetSubjectById/{id}")]

        public async Task<ActionResult<ResponseModel<Subject>>> GetSubjectById(int id)
        {
            var subject = await _subjectInterface.GetSubjectById(id);
            if (subject.Dados == null)
            {
                return NotFound(subject);
            }
            return Ok(subject);
        }


    }
}
