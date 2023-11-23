using System.Collections.Generic;
using backend.Business.Interfaces;
using backend.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        IMemberService _MemberService;
        public MemberController(IMemberService MemberService)
        {
            _MemberService = MemberService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get()
        {
            return Ok(_MemberService.GetAll());
        }

        [HttpPost]
        public ActionResult<Member> Save(Member Member)
        {
            return Ok(_MemberService.Save(Member));

        }

        [HttpPut]
        public ActionResult<Member> Update( Member Member)
        {
            return Ok(_MemberService.Update(Member));

        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_MemberService.Delete(id));

        }
        [HttpGet("{id:int}")]
        public ActionResult<Member> GetById(int id)
        {
            return Ok(_MemberService.GetById(id));
        }

    }
}
