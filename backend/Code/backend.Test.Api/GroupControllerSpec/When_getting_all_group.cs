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
    public class When_getting_all_group : UsingGroupControllerSpec
    {
        private ActionResult<IEnumerable<Group>> _result;

        private IEnumerable<Group> _all_group;
        private Group _group;

        public override void Context()
        {
            base.Context();

            _group = new Group{
                number = "number",
                name = "name",
                type = "type",
                streetAddress = "streetAddress",
                contactDetails = "contactDetails"
            };

            _all_group = new List<Group> { _group};
            _groupService.GetAll().Returns(_all_group);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _groupService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Group>>();

            List<Group> resultList = resultListObject as List<Group>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_group);
        }
    }
}
