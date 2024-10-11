using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Crypto.Lab2;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers.Lab2Controllers
{
    [Route("api/[controller]")]
    public class EulerController : Controller
    {
        [HttpPost()]
        public async Task<ActionResult<string>> Post(string m)
        {
            int a;

            try
            {
                if (m == null) throw new FormatException();

                a = Convert.ToInt32(m);
            }
            catch (FormatException)
            {
                ModelState.AddModelError("Error", "Некорректные параметры");
                return BadRequest(ModelState);
            }

            return await Task.Run(() => Algebra.Euler(a).ToString());
        }
    }
}
