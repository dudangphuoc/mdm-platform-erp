using Abp.AspNetCore.Dependency;
using Abp.Dependency;

namespace SelfHost.Startup
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseCastleWindsor(IocManager.Instance.IocContainer);
    }
}
