using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.Entities.Entities;

namespace backend.Test.Api.MemberControllerSpec
{
    public class When_updating_member : UsingMemberControllerSpec
    {
        private ActionResult<Member > _result;
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

            _memberService.Update( _member).Returns(_member);
            
        }
        public override void Because()
        {
            _result = subject.Update( _member);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _memberService.Received(1).Update( _member);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Member>();

            var resultList = resultListObject as Member;

            resultList.ShouldBe(_member);
        }
    }
}
