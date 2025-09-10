using APITransacitons.Data;
using APITransacitons.DTOs.Subject;
using APITransacitons.Models;
using Microsoft.EntityFrameworkCore;

namespace APITransacitons.Services.SubjectService
{
    public class SubjectService : SubjectInterface

    {
        private readonly AppDbContext _context;
        public SubjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<Subject>>> Deletesubject(int id)
        {
            var response = new ResponseModel<List<Subject>>();

            try
            {

                var subject = await _context.Subjects
                    .FirstOrDefaultAsync(s => s.id == id);

                if (subject == null)
                {

                    response.mensagem = "Subject not found.";
                    return response;

                }

                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
                
                response.Dados = await _context.Subjects.ToListAsync();
                response.mensagem = "Subject deleted successfully.";

                response.status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.mensagem = ex.Message;
                response.status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<Subject>>> GetAllSubjects()
        {
            ResponseModel<List<Subject>> response = new ResponseModel<List<Subject>>();
            try
            {
                var subjects = await _context.Subjects.ToListAsync();
                response.Dados = subjects;

                response.mensagem = "Subjects retrieved successfully.";
                response.status = true;

                return response;


            }
            catch (Exception ex)
            {
                response.mensagem = ex.Message;
                response.status = false; 
                return response;
            }
        }

        public async Task<ResponseModel<Subject>> GetSubjectById(int id)
        {

            ResponseModel<Subject> response = new ResponseModel<Subject>();
            try
            {

                var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.id == id);
                if (subject == null)
                {
                    response.mensagem = "Subject not found.";
                    response.status = false;
                    return response;
                }
                response.Dados = subject;
                response.mensagem = "Subject retrieved successfully.";
                response.status = true;
                return response;

            }
            catch (Exception ex)
            {

                response.mensagem = ex.Message;
                response.status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<Subject>>> PostSubject(NewSubjectDTO newSubjectDTO)
        {
            ResponseModel<List<Subject>> response = new ResponseModel<List<Subject>>();

            try
            {

                var subjcet = new Subject()
                {
                    name = newSubjectDTO.name,
                    age = newSubjectDTO.age
                };

                _context.Subjects.Add(subjcet);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Subjects.ToListAsync();
                response.mensagem = "Subject created successfully.";
                response.status = true;
                return response;


            } catch (Exception ex)
            {
                response.mensagem = ex.Message;
                response.status = false;
                return response;
            }

        }

        public async Task<ResponseModel<List<Subject>>> Updatesubject(UpdateSubjectDTO updateSubjectDTO)
        {
            ResponseModel<List<Subject>> response = new ResponseModel<List<Subject>>();

            try
            {

                var subject = await _context.Subjects
                    .FirstOrDefaultAsync(s => s.id == updateSubjectDTO.id);

                if(subject == null)
                {
                    response.mensagem = "Subject not found.";
                    response.status = false;
                    return response;
                }

                subject.name = updateSubjectDTO.name;
                subject.age = updateSubjectDTO.age;
                await _context.SaveChangesAsync();
                response.Dados = await _context.Subjects.ToListAsync();
                response.mensagem = "Subject updated successfully.";
                response.status = true;

                return response;


            }
            catch (Exception ex)
            {
                response.mensagem = ex.Message;
                response.status = false;
                return response;
            }

        }


        /*
        public async Task<ResponseModel<Transaction>> GetTransactionWithSubjectById(int transactionId)
        {
            ResponseModel<Transaction> response = new ResponseModel<Transaction>();
            try
            {
                // 1. FAZ UMA ÚNICA CHAMADA AO BANCO DE DADOS
                // 2. USA .Include() NA PROPRIEDADE DE NAVEGAÇÃO "Subject"
                var transaction = await _context.Transactions
                                                .Include(t => t.idSubject) // Carrega o objeto Subject relacionado
                                                .FirstOrDefaultAsync(t => t.id == transactionId);

                // 4. VERIFICA SE A TRANSAÇÃO FOI ENCONTRADA
                if (transaction == null)
                {
                    response.mensagem = "Transação não encontrada.";
                    response.status = false;
                    return response;
                }

                response.Dados = transaction;
                response.mensagem = "Transação e Pessoa recuperadas com sucesso.";
                response.status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.mensagem = ex.Message;
                response.status = false;
                return response;
            }
        }

        */
    }
}
