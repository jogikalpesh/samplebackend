using NSubstitute;
using backend.Test.Framework;
using backend.Business.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.GroupServiceSpec
{
    public abstract class UsingGroupServiceSpec : SpecFor<GroupService>
    {
        protected IGroupRepository _groupRepository;

        public override void Context()
        {
            _groupRepository = Substitute.For<IGroupRepository>();
            subject = new GroupService(_groupRepository);

        }

    }
}
