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
    public class AB
    {
        public string a { get; set; }
        public string b { get; set; }
    }

    [Route("api/[controller]")]
    public class EuclidController : Controller
    {
        [HttpPost()]
        public async Task<ActionResult<string>> Post(AB ab)
        {
            BigInteger a, b;

            try
            {
                if (ab.a == null || ab.b == null) throw new FormatException();
                a = BigInteger.Parse(ab.a);
                b = BigInteger.Parse(ab.b);
            }
            catch (FormatException)
            {
                ModelState.AddModelError("Error", "Некорректные параметры");
                return BadRequest(ModelState);
            }

            return await Task.Run(() => Algebra.Euclid(a, b).ToString());
        }
    }
}
