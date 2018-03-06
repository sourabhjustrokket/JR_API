using JR_API.Entities;
using JR_API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JR_API.Services
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAll();
        Tag GetById(int id);
        Tag GetByName(string TagName);
        Tag Create(Tag tag);
        void Update(Tag tag);
        void Delete(int id);
        void CreateTagRelation(List<TagRelationship> tagRelationship); 
    }
    public class TagService : ITagService
    {
        private DataContext _context;
        public TagService(DataContext context)
        {
            _context = context;
        }
        public Tag Create(Tag tag)
        {
            if (string.IsNullOrEmpty(tag.TagName) || string.IsNullOrEmpty(tag.TagName))
            {
                return null;
            }
            tag.CreatedDate = DateTime.Now;
            tag.ModifiedDate = DateTime.Now;
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag;
        }

        public void CreateTagRelation(List<TagRelationship> lstTagRelationship)
        {
            foreach (var tagRelationship in lstTagRelationship)
            {
                if (_context.TagRelations.Where(x => x.TagFamilyId == tagRelationship.TagFamilyId && x.TagFamilyMemberId == tagRelationship.TagFamilyMemberId).Count() == 0)
                {
                    _context.TagRelations.Add(tagRelationship);
                }
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags;
        }

        public Tag GetById(int id)
        {
            return _context.Tags.Find(id);
        }

        public Tag GetByName(string TagName)
        {
            var selectedTag = _context.Tags.Where(x => x.TagName == TagName);
            if (selectedTag.Count() > 0)
            {
                return selectedTag.FirstOrDefault();
            }
            return null;
        }

        public void Update(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
