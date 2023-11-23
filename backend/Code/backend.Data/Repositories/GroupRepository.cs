using backend.Data.Interfaces;
using backend.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace backend.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;        

        public GroupRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Group> GetAll()
        {            
            return _context.Group.ToList();
        }

        public bool Save(Group entity)
        {
            if (entity == null)
            return false;
            _context.Group.Add(entity);
            var created= _context.SaveChanges();
            return created>0;
        }

        public Group Update(Group entity)
        {     
             _context.Group.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {          

            int deleted = 0;
            var entity = _context.Group.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.Remove(entity);
                deleted = _context.SaveChanges();
            }
            return deleted > 0;
        }
        public Group GetById(int id)
        {
            return _context.Group.FirstOrDefault(x => x.Id == id);            
             
        }
    }
}
