using Brief.Models;
using Brief.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace Brief.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class BriefController: ControllerBase
    {
        private readonly AppContext dbContext;
        public BriefController(AppContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public BriefViewModel FormFields() => new BriefViewModel();

        [HttpPost]
        public void SaveForm()
        {
            var dict = Request.Form.ToDictionary();
            dbContext.Forms.Add(new Form()
            {
                SerializedForm = JsonConvert.SerializeObject(dict)
            });
            dbContext.SaveChanges();
        }
    }
}
