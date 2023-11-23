using backend.Data.Interfaces;
using backend.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace backend.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext _context;        

        public MemberRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Member> GetAll()
        {            
            return _context.Member.ToList();
        }

        public bool Save(Member entity)
        {
            if (entity == null)
            return false;
            _context.Member.Add(entity);
            var created= _context.SaveChanges();
            return created>0;
        }

        public Member Update(Member entity)
        {     
             _context.Member.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {          

            int deleted = 0;
            var entity = _context.Member.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.Remove(entity);
                deleted = _context.SaveChanges();
            }
            return deleted > 0;
        }
        public Member GetById(int id)
        {
            return _context.Member.FirstOrDefault(x => x.Id == id);            
             
        }
    }
}
