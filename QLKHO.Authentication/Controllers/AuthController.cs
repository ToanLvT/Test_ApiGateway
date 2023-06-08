using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLKHO.Authentication.Models;
using System.Data;

namespace QLKHO.Authentication.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Route("list")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = new List<string> { "Authen: A", "Authen: B" };
                return Ok(result);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok("Có lỗi xảy ra");
            }
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult Login(AuthModel model)
        {
            try
            {
                var list_User = new List<AuthModel>
                {
                    new AuthModel { code =1 ,username="admin", password="123456", Role="Admin"},
                    new AuthModel { code =2 ,username="user", password="1234", Role="User" },
                    new AuthModel { code =3 ,username="hethong", password="12345", Role="Admin,User" },
                    new AuthModel { code =4 ,username="Guest", password="1", Role="" },
                };

                if (model == null) throw new Exception("Giá trị truyền vào rỗng.");
                var user = list_User.Where(p => p.username == model.username && p.password == model.password && p.code == model.code).FirstOrDefault();
                if (user == null) throw new Exception("Tài khoản không hợp lệ.");

                var token = model.GetToken(user);
                var result = token;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Có lỗi xảy ra");
            }
        }
    }
}
