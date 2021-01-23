using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NorthwindBackend.BLL.DependencyResolvers.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindBackend.WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                
            // hangi service provider'ını kullandığımızı söyleyeceğiz.


                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                 // contanier'ı configure ediyoruz. autofac kullanılacak da hangi modülle kullanacaz?
                .ConfigureContainer<ContainerBuilder>(builder=> 
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
