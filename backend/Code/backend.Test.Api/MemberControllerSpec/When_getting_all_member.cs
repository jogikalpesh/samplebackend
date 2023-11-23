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
    public class When_getting_all_member : UsingMemberControllerSpec
    {
        private ActionResult<IEnumerable<Member>> _result;

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
            _memberService.GetAll().Returns(_all_member);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _memberService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Member>>();

            List<Member> resultList = resultListObject as List<Member>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_member);
        }
    }
}
