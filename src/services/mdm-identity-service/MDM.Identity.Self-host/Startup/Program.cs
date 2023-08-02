using Abp.AspNetCore.Dependency;
using Abp.Dependency;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SelfHost.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>

        Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                //webBuilder.UseUrls("http://+:80");
                //webBuilder.ConfigureKestrel(options =>
                //{
                //    options.ListenAnyIP(51934);  // whatever your port
                //});
            })

            .UseCastleWindsor(IocManager.Instance.IocContainer);
    }
}
