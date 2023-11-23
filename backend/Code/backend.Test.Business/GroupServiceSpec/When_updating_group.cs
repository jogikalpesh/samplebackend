using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.Entities.Entities;


namespace backend.Test.Business.GroupServiceSpec
{
    public class When_updating_group : UsingGroupServiceSpec
    {
        private Group _result;
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

            _groupRepository.Update( _group).Returns(_group);
            
        }
        public override void Because()
        {
            _result = subject.Update( _group);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _groupRepository.Received(1).Update( _group);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Group>();

            _result.ShouldBe(_group);
        }
    }
}
