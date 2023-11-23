using backend.Business.Interfaces;
using backend.Data.Interfaces;
using backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Business.Services
{
    public class GroupService : IGroupService
    {
        IGroupRepository _GroupRepository;

        public GroupService(IGroupRepository GroupRepository)
        {
           this._GroupRepository = GroupRepository;
        }
        public IEnumerable<Group> GetAll()
        {
            return _GroupRepository.GetAll();
        }

        public Group Save(Group Group)
        {
            _GroupRepository.Save(Group);
            return Group;
        }

        public Group Update(Group Group)
        {
            return _GroupRepository.Update( Group);
        }

        public bool Delete(int id)
        {
            return _GroupRepository.Delete(id);
        }
        public Group GetById(int id)
        {
            return _GroupRepository.GetById(id);
        }
    }
}
