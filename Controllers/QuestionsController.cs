using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JR_API.Entities;
using JR_API.Helpers;
using JR_API.Services;
using AutoMapper;

namespace JR_API.Controllers
{
    [Route("Questions")]
    public class QuestionsController : Controller
    {
        private IQuestionService _questionService;
        private IMapper _mapper;
        public QuestionsController(IQuestionService questionService,
            IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        // GET: api/Questions
        [HttpGet]
        public IEnumerable<Question> GetQuestions()
        {
            return _questionService.GetQuestions();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public IActionResult GetQuestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = _questionService.GetQuestion(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public IActionResult PutQuestion([FromRoute] int id, [FromBody] Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_questionService.EditQuestion(id,question));
            }
            catch (Exception ex)
            {

            }
            return NoContent();
        }

        // POST: api/Questions
        [HttpPost]
        public IActionResult PostQuestion([FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            question=_questionService.SubmitQuestion(question);

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        }
    }
}