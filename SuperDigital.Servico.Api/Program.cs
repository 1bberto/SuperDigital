using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SuperDigital
{
    /// <summary>
    /// Classe Program
    /// </summary>
    public class Program
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// CreateWebHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        #endregion
        #endregion
    }
}
