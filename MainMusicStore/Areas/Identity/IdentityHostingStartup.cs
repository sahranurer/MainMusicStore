
using Microsoft.AspNetCore.Hosting;


[assembly: HostingStartup(typeof(MainMusicStore.Areas.Identity.IdentityHostingStartup))]
namespace MainMusicStore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}