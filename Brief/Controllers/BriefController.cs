using System.Collections.Generic;
using Brief.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brief.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BriefController: ControllerBase
    {
        private readonly FormReflectionGenerator formReflectionGenerator;

        public BriefController(FormReflectionGenerator formReflectionGenerator)
        {
            this.formReflectionGenerator = formReflectionGenerator;
        }

        [HttpGet]
        public List<BaseField> FormFields()
        {
            return formReflectionGenerator.GetForm();
        }
    }
}
