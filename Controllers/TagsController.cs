using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JR_API.Services;
using AutoMapper;
using JR_API.Helpers;
using Microsoft.AspNetCore.Authorization;
using JR_API.Dtos;
using JR_API.Entities;
using System.Security.Claims;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JR_API.Controllers
{
    [Route("[controller]")]
    public class TagsController : Controller
    {
        private ITagService _TagService;
        private IMapper _mapper;

        public TagsController(ITagService tagService,
            IMapper mapper)
        {
            _TagService = tagService;
            _mapper = mapper;
        }

        [Authorize(Roles ="A")]
        [HttpPost]
        public IActionResult Create([FromBody]TagDto tagDto)
        {
            // map dto to entity
            var tag = _mapper.Map<Tag>(tagDto);

            try
            {
                // save 
                tag.TagSymbol="#"+ Regex.Replace(tagDto.TagName, @"[^0-9a-zA-Z]+", "");
                _TagService.Create(tag);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var tags = _TagService.GetAll();
            var tagDtos = _mapper.Map<IList<TagDto>>(tags);
            return Ok(tagDtos);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var tag = _TagService.GetById(id);
            var tagDto = _mapper.Map<TagDto>(tag);
            return Ok(tagDto);
        }
        [HttpGet("SearchSecondaryTag")]
        [AllowAnonymous]
        public IActionResult SearchSecondaryTag(string searchTag)
        {
            return Ok(_TagService.SearchSecondaryTag(searchTag));
        }
    }
}
