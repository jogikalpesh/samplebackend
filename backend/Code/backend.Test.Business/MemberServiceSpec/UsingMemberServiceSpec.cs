using NSubstitute;
using backend.Test.Framework;
using backend.Business.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.MemberServiceSpec
{
    public abstract class UsingMemberServiceSpec : SpecFor<MemberService>
    {
        protected IMemberRepository _memberRepository;

        public override void Context()
        {
            _memberRepository = Substitute.For<IMemberRepository>();
            subject = new MemberService(_memberRepository);

        }

    }
}
