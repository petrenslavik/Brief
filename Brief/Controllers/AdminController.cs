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
        private readonly AppContext dbContext;
        public AdminController(AppContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult LoginUser(string login, string password)
        {
            if (login == "admin" && password == "admin")
            {
                return Ok();
            }
            return BadRequest("Invalid login or password");
            //dbContext.SaveChanges();
        }

        [HttpGet]
        public IQueryable<object> Forms()
        {
            return dbContext.Forms;
        }

        [HttpDelete]
        public void DeleteForm(int id)
        {
            var form = dbContext.Forms.FirstOrDefault(x => x.Id == id);
            dbContext.Forms.Remove(form);
            dbContext.SaveChanges();
        }
    }
}
