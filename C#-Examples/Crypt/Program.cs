using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Crypto.Lab1.DESAlgo;
using System.Text;
using ModeWork;
using Crypto;
using System.Numerics;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var message = 0x1234567890123444;
            var key = 0x1234567890123440;
            var key1 = 0x2323232323232666;
            foreach (var item in BitConverter.GetBytes(message))
                Console.Write(" " + item);
            Console.WriteLine();

            var des = new DES((ulong)key);
            var ecb = new ECB(des);
            var tmp = ecb.Encode(BitConverter.GetBytes(message));
            foreach (var item in tmp)
                Console.Write(" " + item);
            Console.WriteLine();

            var des1 = new DES((ulong)key1);
            var ecb1 = new ECB(des1);
            var tmp1 = ecb1.Decode(tmp);

            foreach (var item in tmp1)
                Console.Write(" " + item);
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
