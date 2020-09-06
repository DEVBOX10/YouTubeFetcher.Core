using Microsoft.Extensions.DependencyInjection;
using YouTubeFetcher.Core.Factories;
using YouTubeFetcher.Core.Factories.Interfaces;
using YouTubeFetcher.Core.Services;
using YouTubeFetcher.Core.Services.Interfaces;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Extensions
{
    /// <summary>
    /// Extensions which are practical for working with dependency injection
    /// </summary>
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Adds all needed dependencies for the YouTubeFetcher.Core library
        /// </summary>
        /// <param name="services"></param>
        public static void AddYouTubeService(this IServiceCollection services)
        {
            // Configurations for library
            services.Configure();

            // Add library services to the collection
            services.AddServices();

            // Add external dependencies needed for the library to run
            services.AddHttpClient();
        }

        private static void Configure(this IServiceCollection services)
        {
            services.Configure<DecryptorSettings>(a => new DecryptorSettings());
            services.Configure<YouTubeSettings>(a => new YouTubeSettings());
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDecryptorServiceFactory, DecryptorServiceFactory>();
            services.AddSingleton<IYouTubeServiceFactory, YouTubeServiceFactory>();
            services.AddSingleton<IDecryptorService, DecryptorService>();
            services.AddSingleton<IYouTubeService, YouTubeService>();
        }
    }
}
