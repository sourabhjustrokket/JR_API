using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JR_API.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        [ForeignKey("user")]
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string tagIds { get; set; }
        public virtual User user { get; set; }
        public virtual ICollection<Tag> tags { get; set; }
    }
}
