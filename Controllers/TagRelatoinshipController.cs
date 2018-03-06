using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JR_API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using JR_API.Dtos;
using JR_API.Entities;
using JR_API.Helpers;

namespace JR_API.Controllers
{
    [Route("[controller]")]
    public class TagRelatoinshipController : Controller
    {
        private ITagService _TagService;
        private IMapper _mapper;

        public TagRelatoinshipController(ITagService tagService,
            IMapper mapper)
        {
            _TagService = tagService;
            _mapper = mapper;
        }

        [Authorize(Roles = "A")]
        [HttpPost]
        public IActionResult Create([FromBody]TagRelationDto tagRelationDto)
        {
            try
            {
                List<TagRelationship> lstTr=new List<TagRelationship>();
                // save 
                foreach (var item in tagRelationDto.FamilyTagMembers)
                {
                    lstTr.Add(new TagRelationship()
                    {
                        IsActive = true,
                        ModifiedDate = DateTime.Now,
                        CreatedDate = DateTime.Now,
                        TagFamilyId = tagRelationDto.FamilyTag.Id,
                        TagFamilyMemberId = item.Id
                    });
                }
                _TagService.CreateTagRelation(lstTr);
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
    }
}