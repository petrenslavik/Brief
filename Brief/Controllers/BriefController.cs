using Brief.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Brief.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class BriefController: ControllerBase
    {
        [HttpGet]
        public BriefViewModel FormFields() => new BriefViewModel();

        [HttpPost]
        public void SaveForm(BriefViewModel model)
        {

        }
    }
}
