using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using Microsoft.AspNetCore;

namespace IdentityServer4withRSA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer4 using RSA";

            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://localhost:5001")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}
