using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.Business.Interfaces;


namespace backend.Test.Api.MemberControllerSpec
{
    public abstract class UsingMemberControllerSpec : SpecFor<MemberController>
    {
        protected IMemberService _memberService;

        public override void Context()
        {
            _memberService = Substitute.For<IMemberService>();
            subject = new MemberController(_memberService);

        }

    }
}
