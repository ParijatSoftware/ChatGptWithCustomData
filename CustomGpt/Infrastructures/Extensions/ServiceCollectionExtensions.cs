using CustomGpt.Service.Abstracts;
using CustomGpt.Service.Services;

namespace CustomGpt.Web.Infrastructures.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ISearchService, SearchService>();
        }

    }
}
