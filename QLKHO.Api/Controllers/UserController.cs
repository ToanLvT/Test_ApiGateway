
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLKHO.Api.Models;

namespace QLKHO.Api.Controllers
{
   // [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize]
        [Route("list")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = new List<string> { "Nguyễn Văn A", "Trần văn B", "Trần văn C", "Trần văn D" };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Có lỗi xảy ra");
            }
        }

        [Authorize]
        [Route("{id}")]
        [HttpGet]
        public ActionResult Getkey(long id)
        {
            try
            {
                var result = new List<string> { "Nguyễn Văn A" + id, "Trần văn B" + id, "Trần văn C" + id, "Trần văn D" + id };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Có lỗi xảy ra");
            }
        }

        [Authorize]
        [Route("save")]
        [HttpPost]
        public ActionResult Save(UserModel model)
        {
            try
            {
                var result = model;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Có lỗi xảy ra");
            }
        }
    }
}
