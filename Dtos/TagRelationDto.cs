﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JR_API.Dtos
{
    public class TagRelationDto
    {
        public int Id { get; set; }
        public int FamilyTagId { get; set; }
        public List<TagDto> MembersTagId { get; set; }
    }
}
