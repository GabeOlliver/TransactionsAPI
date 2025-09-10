using APITransacitons.DTOs.Subject;
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

        [HttpPost]
        public async Task<ActionResult<ResponseModel<Subject>>> PostSubject(NewSubjectDTO newSubjectDTO)
        {
            var subject = await _subjectInterface.PostSubject(newSubjectDTO);
            if (subject.Dados == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Dados}, subject); // VAMO BORA 
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ResponseModel<Subject>>> UpdateSubject(UpdateSubjectDTO updateSubjectDTO)
        {
            var subject = await _subjectInterface.Updatesubject(updateSubjectDTO);
            if (subject.Dados == null)
            {
                return NotFound(subject);
            }
            return Ok(subject);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<Subject>>> DeleteSubject(int id)
        {
            var subject = await _subjectInterface.Deletesubject(id);
            if (subject.Dados == null)
            {
                return NotFound(subject);
            }
            return Ok(subject);
        }


    }
}
