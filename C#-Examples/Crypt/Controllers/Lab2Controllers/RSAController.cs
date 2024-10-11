using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Crypto.Lab2;
using System.Numerics;
using System;

namespace Server.Controllers.BitOperationControlles
{
    [Route("api/[controller]")]
    public class RSAController : ControllerBase
    {
        public static IWebHostEnvironment _environment;

        public RSAController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        public async Task<ActionResult<string>> Post(IFormFile message, IFormFile key)
        {
            byte[] fileBytesMessage;

            if (message == null)
            {
                ModelState.AddModelError("Error", "Некорректные параметры");
                return BadRequest(ModelState);
            }

            if (message.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    message.CopyTo(ms);
                    fileBytesMessage = ms.ToArray();
                }

                var rsa = new RSA();
                byte[] result;
                string pathCode = "(RSA)" + message.FileName;
                if (key == null)
                {
                    result = rsa.Encode(fileBytesMessage);
                    var pathKey = message.FileName + ".key";
                    var fileKey = rsa.GetCloseKey().Item1.ToByteArray().Concat(rsa.GetCloseKey().Item1.ToByteArray()).ToArray();
                    using (var fs = System.IO.File.Create(_environment.WebRootPath + "/" + pathCode))
                    {
                        fs.Write(result, 0, result.Count());
                        fs.Flush();
                    }
                    using (var fs = System.IO.File.Create(_environment.WebRootPath + "/" + pathKey))
                    {
                        fs.Write(fileKey, 0, fileKey.Count());
                        fs.Flush();
                    }

                    return pathCode + " " + pathKey;
                }
                else
                {
                    byte[] byteKey;
                    using (var ms = new MemoryStream())
                    {
                        key.CopyTo(ms);
                        byteKey = ms.ToArray();
                    }

                    var d = new BigInteger(byteKey.Take(256).ToArray());
                    var n = new BigInteger(byteKey.Skip(256).Take(256).ToArray());
                    result = rsa.Decode(fileBytesMessage, d, n);
                    using (var fs = System.IO.File.Create(_environment.WebRootPath + "/" + pathCode))
                    {
                        fs.Write(result, 0, result.Count());
                        fs.Flush();
                    }

                    return pathCode;
                }


            }
            else
            {
                return BadRequest();
            }
        }

    }
}
