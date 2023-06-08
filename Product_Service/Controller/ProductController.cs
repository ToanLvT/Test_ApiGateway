using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Service.Models;

namespace Product.Service.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [Authorize]
        [Route("list")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = new List<string> { "Product 1", "Product 2", "Product 3", "Product 4" };
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
                var result = new List<string> { "Product 1_" + id, "Product 2_" + id, "Product 3_" + id, "Product 4_" + id };
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
        public ActionResult Save(ProductModel model)
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
