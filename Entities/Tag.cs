using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JR_API.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        //public ICollection<TagRelationship> RelatedToFamily { get; set; }
        //public ICollection<TagRelationship> RelatedToMembers { get; set; }
        public string TagSymbol { get; set; }
    }
}
