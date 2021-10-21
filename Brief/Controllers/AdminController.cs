using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brief.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class AdminController : ControllerBase
    {
        [HttpPost]
        public void Login()
        {
            var dict = Request.Form.ToDictionary();
            //dbContext.SaveChanges();
        }
    }
}
