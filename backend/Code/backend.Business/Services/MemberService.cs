using backend.Business.Interfaces;
using backend.Data.Interfaces;
using backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Business.Services
{
    public class MemberService : IMemberService
    {
        IMemberRepository _MemberRepository;

        public MemberService(IMemberRepository MemberRepository)
        {
           this._MemberRepository = MemberRepository;
        }
        public IEnumerable<Member> GetAll()
        {
            return _MemberRepository.GetAll();
        }

        public Member Save(Member Member)
        {
            _MemberRepository.Save(Member);
            return Member;
        }

        public Member Update(Member Member)
        {
            return _MemberRepository.Update( Member);
        }

        public bool Delete(int id)
        {
            return _MemberRepository.Delete(id);
        }
        public Member GetById(int id)
        {
            return _MemberRepository.GetById(id);
        }
    }
}
