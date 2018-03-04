using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JR_API.Entities
{
    public class TagRelationship
    {
        public int Id { get; set; }
        public string TagFamily { get; set; }
        public string TagFamilyMember { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
