using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using UmbracoDictionaryDeliveryAPI.Swagger;

namespace UmbracoDictionaryDeliveryAPI;
public class Composer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.ConfigureOptions<ConfigureDictionaryUmbracoDeliveryApiSwaggerGenOptions>();
    }
}
