using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JR_API.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string tagIds { get; set; }
        public List<TagDto> tags { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public UserDto user { get; set; }
    }
}
