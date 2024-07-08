using Umbraco.Cms.Web.Common.Routing;

namespace UmbracoDictionaryDeliveryAPI.Controller.Attribute;

internal sealed class VersionedDeliveryApiRouteAttribute : BackOfficeRouteAttribute
{
    public VersionedDeliveryApiRouteAttribute(string template)
        : base($"delivery/api/v{{version:apiVersion}}/{template.TrimStart('/')}")
    {
    }
}
