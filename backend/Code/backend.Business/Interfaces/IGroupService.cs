using backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Business.Interfaces
{
    public interface IGroupService
    {      
        IEnumerable<Group> GetAll();
        Group Save(Group classification);
        Group Update(Group classification);
        bool Delete(int id);
        Group  GetById(int id);

    }
}
