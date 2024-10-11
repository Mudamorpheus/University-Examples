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
    public class AKM
    {
        public string a { get; set; }
        public string k { get; set; }
        public string m { get; set; }

    }

    [Route("api/[controller]")]
    public class PowModController : Controller
    {
        [HttpPost()]
        public async Task<ActionResult<string>> Post(AKM akm)
        {
            BigInteger a;
            uint k, m;

            try
            {
                if (akm.a == null || akm.k == null || akm.m == null) throw new FormatException();
                a = BigInteger.Parse(akm.a);
                k = Convert.ToUInt32(akm.k, 10);
                m = Convert.ToUInt32(akm.m, 10);
            }
            catch (FormatException)
            {
                ModelState.AddModelError("Error", "Некорректные параметры");
                return BadRequest(ModelState);
            }

            return await Task.Run(() => Algebra.PowMod(a, k, m).ToString());
        }
    }
}
