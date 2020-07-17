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

            services.AddScoped<IHttpClientFactory, HttpClientFactory>();
            services.AddScoped<IDecryptorServiceFactory, DecryptorServiceFactory>();
            services.AddScoped<IYouTubeServiceFactory, YouTubeServiceFactory>();
            services.AddScoped<IDecryptorService, DecryptorService>();
            services.AddScoped<IYouTubeService, YouTubeService>();
        }
    }
}
