using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UmbracoDictionaryDeliveryAPI.Swagger;

public class ConfigureDictionaryUmbracoDeliveryApiSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions swaggerGenOptions)
    {
        swaggerGenOptions.OperationFilter<SwaggerDictionaryDocumentationFilter>();
    }
}
