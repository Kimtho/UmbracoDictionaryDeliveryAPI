using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using UmbracoDictionaryDeliveryAPI.Controller;

namespace UmbracoDictionaryDeliveryAPI.Swagger;

internal class SwaggerDictionaryDocumentationFilter : SwaggerDocumentationFilterBase<DictionaryController>
{
    protected override string DocumentationLink => "https://docs.umbraco.com/umbraco-cms/reference/content-delivery-api";

    protected override void ApplyOperation(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Accept-Language",
            In = ParameterLocation.Header,
            Required = false,
            Description = "Defines the language to return. Use this when querying language variant content items.",
            Schema = new OpenApiSchema { Type = "string" },
            Examples = new Dictionary<string, OpenApiExample>
            {
                { "Default", new OpenApiExample { Value = new OpenApiString(string.Empty) } },
                { "English culture", new OpenApiExample { Value = new OpenApiString("en-us") } }
            }
        });
        AddApiKey(operation);
    }

    protected override void ApplyParameter(OpenApiParameter parameter, ParameterFilterContext context)
    {

    }
}