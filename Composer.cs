using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Services;
using UmbracoDictionaryDeliveryAPI.Swagger;

namespace UmbracoDictionaryDeliveryAPI;
public class Composer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<IApiContentPathProvider, ApiContentPathProvider>();
        builder.Services.ConfigureOptions<ConfigureDictionaryUmbracoDeliveryApiSwaggerGenOptions>();
    }
}
