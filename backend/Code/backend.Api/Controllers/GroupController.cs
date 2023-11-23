using System.Collections.Generic;
using backend.Business.Interfaces;
using backend.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        IGroupService _GroupService;
        public GroupController(IGroupService GroupService)
        {
            _GroupService = GroupService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Group>> Get()
        {
            return Ok(_GroupService.GetAll());
        }

        [HttpPost]
        public ActionResult<Group> Save(Group Group)
        {
            return Ok(_GroupService.Save(Group));

        }

        [HttpPut]
        public ActionResult<Group> Update( Group Group)
        {
            return Ok(_GroupService.Update(Group));

        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_GroupService.Delete(id));

        }
        [HttpGet("{id:int}")]
        public ActionResult<Group> GetById(int id)
        {
            return Ok(_GroupService.GetById(id));
        }

    }
}
