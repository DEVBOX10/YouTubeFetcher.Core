using Microsoft.Extensions.DependencyInjection;
using YouTubeFetcher.Core.Factories;
using YouTubeFetcher.Core.Factories.Interfaces;
using YouTubeFetcher.Core.Services;
using YouTubeFetcher.Core.Services.Interfaces;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void AddYouTubeService(this IServiceCollection services)
        {
            services.AddSingleton(new DecryptorSettings());
            services.AddSingleton(new YouTubeSettings());

            services.AddSingleton<IHttpClientFactory, HttpClientFactory>();
            services.AddSingleton<IDecryptorServiceFactory, DecryptorServiceFactory>();
            services.AddSingleton<IYouTubeServiceFactory, YouTubeServiceFactory>();
            services.AddSingleton<IDecryptorService, DecryptorService>();
            services.AddSingleton<IYouTubeService, YouTubeService>();
        }
    }
}
