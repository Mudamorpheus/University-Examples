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
    public class PrimeNumbersController : Controller
    {
        [HttpPost()]
        public async Task<ActionResult<string>> Post(string m)
        {
            BigInteger a;

            try
            {
                if (m == null) throw new FormatException();

                a = BigInteger.Parse(m);
            }
            catch (FormatException)
            {
                ModelState.AddModelError("Error", "Некорректные параметры");
                return BadRequest(ModelState);
            }
            var result = new StringBuilder();
            var numbers = Algebra.GetPrimeNumbers(a);

            foreach(var item in numbers)
                result.Append(item.ToString() + " ");

            return await Task.Run(() => result.ToString());
        }
    }
}
