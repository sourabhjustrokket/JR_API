using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JR_API.Entities
{
    public class TagRelationship
    {
        public int Id { get; set; }
        [ForeignKey("TagFamily")]
        public int TagFamilyId { get; set; }
        [ForeignKey("TagFamilyMember")]
        public int TagFamilyMemberId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual Tag TagFamily { get; set; }
        public virtual Tag TagFamilyMember { get; set; }
        public bool IsActive { get; set; }
    }
}
