using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.Entities.Entities;

namespace backend.Test.Api.GroupControllerSpec
{
    public class When_saving_group : UsingGroupControllerSpec
    {
        private ActionResult<Group> _result;

        private Group _group;

        public override void Context()
        {
            base.Context();

            _group = new Group
            {
                number = "number",
                name = "name",
                type = "type",
                streetAddress = "streetAddress",
                contactDetails = "contactDetails"
            };

            _groupService.Save(_group).Returns(_group);
        }
        public override void Because()
        {
            _result = subject.Save(_group);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _groupService.Received(1).Save(_group);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Group>();

            var resultList = (Group)resultListObject;

            resultList.ShouldBe(_group);
        }
    }
}
