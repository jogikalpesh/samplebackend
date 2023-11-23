using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.Entities.Entities;

namespace backend.Test.Business.GroupServiceSpec
{
    public class When_getting_all_group : UsingGroupServiceSpec
    {
        private IEnumerable<Group> _result;

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
            _groupRepository.GetAll().Returns(_all_group);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _groupRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Group>>();

            List<Group> resultList = _result as List<Group>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_group);
        }
    }
}
