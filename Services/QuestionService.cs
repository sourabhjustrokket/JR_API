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
        IEnumerable<Question> GetQuestionsForAdmin(bool IsApproved, bool IsActive);
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
            List<Question> lstQuestions = _context.Questions.Where(x => x.IsApproved == true && x.IsActive == true).ToList();
            foreach (Question item in lstQuestions)
            {
                try
                {
                    var itemArr = item.tagIds.Split(",").Select(Int32.Parse).ToList();
                    for (int i = 0; i < itemArr.Count; i++)
                    {
                        item.tags.Add(_context.Tags.Where(x => x.Id == itemArr[i]).FirstOrDefault());
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return lstQuestions;
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

        public IEnumerable<Question> GetQuestionsForAdmin(bool IsApproved, bool IsActive)
        {
            List<Question> lstQuestions = _context.Questions.Include(x=>x.tags).Where(x => x.IsApproved == IsApproved && x.IsActive == IsActive).ToList();

            foreach (Question item in lstQuestions)
            {
                try
                {
                    var itemArr=item.tagIds.Split(",").Select(Int32.Parse).ToList();
                    for (int i= 0; i< itemArr.Count; i++)
                    {
                        item.tags.Add(_context.Tags.Where(x => x.Id == itemArr[i]).FirstOrDefault());
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return lstQuestions;
        }
    }
}
