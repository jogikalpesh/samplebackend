using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.Business.Interfaces;


namespace backend.Test.Api.GroupControllerSpec
{
    public abstract class UsingGroupControllerSpec : SpecFor<GroupController>
    {
        protected IGroupService _groupService;

        public override void Context()
        {
            _groupService = Substitute.For<IGroupService>();
            subject = new GroupController(_groupService);

        }

    }
}
