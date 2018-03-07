using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JR_API.Entities
{
    public class QuestionTag
    {
        public int Id { get; set; }
        [ForeignKey("question")]
        public int QuestionId { get; set; }
        [ForeignKey("tag")]
        public int TagId { get; set; }
        public bool IsActive { get; set; }
        public virtual Question question { get; set; }
        public virtual Tag tag { get; set; }
    }
}
