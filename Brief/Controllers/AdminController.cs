using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brief.Controllers
{
    [EnableCors]
    public class AdminController : Controller
    {
        [HttpPost]
        public ActionResult Login(string login, string password)
        {          
            if(login == "admin" && password == "admin")
            {
                return Ok();
            }
            return BadRequest("Invalid login or password");
            //dbContext.SaveChanges();
        }
    }
}
