using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.Entities.Entities;


namespace backend.Test.Business.MemberServiceSpec
{
    public class When_updating_member : UsingMemberServiceSpec
    {
        private Member _result;
        private Member _member;

        public override void Context()
        {
            base.Context();

            _member = new Member
            {
                name = "name",
                gender = "gender",
                Address = "Address",
                MaritalStatus = "MaritalStatus",
                ssn = "ssn",
                contact = "contact",
                email = "email"
            };

            _memberRepository.Update( _member).Returns(_member);
            
        }
        public override void Because()
        {
            _result = subject.Update( _member);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _memberRepository.Received(1).Update( _member);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Member>();

            _result.ShouldBe(_member);
        }
    }
}
