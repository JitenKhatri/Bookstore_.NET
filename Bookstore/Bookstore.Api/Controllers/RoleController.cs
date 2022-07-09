using System.Linq;
using Bookstore.Models.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        RoleRepository _repo = new RoleRepository();
        [Route("list")]
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _repo.GetRoles();
            ListResponse<RoleModel> roleList = new()
            {
                Results = roles.Results.Select(c => new RoleModel(c)),
                TotalRecords = roles.TotalRecords,
            };

            return Ok(roleList);
        }
    }
}
