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
    public class EuclidExController : Controller
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

            BigInteger x, y;
            var gcd = Algebra.EuclidExBin(a, b, out x, out y);

            var result = x.ToString() + " " + y.ToString() + " " + gcd.ToString();
            return await Task.Run(() => result);
        }
    }
}
