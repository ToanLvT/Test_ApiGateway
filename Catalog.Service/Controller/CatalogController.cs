using Catalog.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Service.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        [Authorize]
        [Route("list")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = new List<string> { "Catalog 1", "Catalog 2", "Catalog 3", "Catalog 4" };
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
                var result = new List<string> { "Catalog 1_" + id, "Catalog 2_" + id, "Catalog 3_" + id, "Catalog 4_" + id };
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
        public ActionResult Save(CatalogModel model)
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
