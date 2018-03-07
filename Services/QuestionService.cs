using JR_API.Entities;
using JR_API.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JR_API.Services
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetQuestions();
        Question GetQuestion(int id);
        Question EditQuestion(int id, Question question);
        Question SubmitQuestion(Question question);
        bool QuestionExists(int id);
    }
    public class QuestionService : IQuestionService
    {
        private DataContext _context;
        public QuestionService(DataContext context)
        {
            _context = context;
        }
        public Question EditQuestion(int id, Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!QuestionExists(id))
                //{
                //    return Question
                //}
                //else
                //{
                //    throw;
                //}
            }
            return question;
        }

        public Question GetQuestion(int id)
        {
            return _context.Questions.SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Question> GetQuestions()
        {
            return _context.Questions;
        }

        public Question SubmitQuestion(Question question)
        {
            question.IsActive = question.IsApproved = false;
            question.ModifiedDate = question.CreatedDate = DateTime.Now;
            _context.Questions.Add(question);
            _context.SaveChanges();
            return question;
        }
        public bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
