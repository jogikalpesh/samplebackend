using backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Business.Interfaces
{
    public interface IMemberService
    {      
        IEnumerable<Member> GetAll();
        Member Save(Member classification);
        Member Update(Member classification);
        bool Delete(int id);
        Member  GetById(int id);

    }
}
