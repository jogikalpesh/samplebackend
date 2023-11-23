using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.Entities.Entities;

namespace backend.Test.Business.MemberServiceSpec
{
    public class When_getting_all_member : UsingMemberServiceSpec
    {
        private IEnumerable<Member> _result;

        private IEnumerable<Member> _all_member;
        private Member _member;

        public override void Context()
        {
            base.Context();

            _member = new Member{
                name = "name",
                gender = "gender",
                Address = "Address",
                MaritalStatus = "MaritalStatus",
                ssn = "ssn",
                contact = "contact",
                email = "email"
            };

            _all_member = new List<Member> { _member};
            _memberRepository.GetAll().Returns(_all_member);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _memberRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Member>>();

            List<Member> resultList = _result as List<Member>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_member);
        }
    }
}
