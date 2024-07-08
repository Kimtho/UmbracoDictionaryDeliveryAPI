using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace UmbracoDictionaryDeliveryAPI.Controller.Attribute;

internal sealed class ValidateStartItemAttribute : TypeFilterAttribute
{
    public ValidateStartItemAttribute()
        : base(typeof(ValidateStartItemFilter))
    {
    }

    private class ValidateStartItemFilter : IActionFilter
    {
        private readonly IRequestStartItemProviderAccessor _requestStartItemProviderAccessor;

        public ValidateStartItemFilter(IRequestStartItemProviderAccessor requestStartItemProviderAccessor)
            => _requestStartItemProviderAccessor = requestStartItemProviderAccessor;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (_requestStartItemProviderAccessor.TryGetValue(out IRequestStartItemProvider? requestStartItemProvider) is false
               || requestStartItemProvider.RequestedStartItem() is null)
            {
                return;
            }

            IPublishedContent? startItem = requestStartItemProvider.GetStartItem();

            if (startItem is null)
            {
                context.Result = new NotFoundObjectResult("The Start-Item could not be found");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
