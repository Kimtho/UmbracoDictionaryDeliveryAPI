using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Extensions;

namespace UmbracoDictionaryDeliveryAPI.Controller.Attribute;

internal sealed class LocalizeFromAcceptLanguageHeaderAttribute : TypeFilterAttribute
{
    public LocalizeFromAcceptLanguageHeaderAttribute()
        : base(typeof(LocalizeFromAcceptLanguageHeaderAttributeFilter))
    {
    }

    private class LocalizeFromAcceptLanguageHeaderAttributeFilter : IActionFilter
    {
        private readonly IRequestCultureService _requestCultureService;

        public LocalizeFromAcceptLanguageHeaderAttributeFilter(IRequestCultureService requestCultureService)
            => _requestCultureService = requestCultureService;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var requestedCulture = _requestCultureService.GetRequestedCulture();
            if (requestedCulture.IsNullOrWhiteSpace())
            {
                return;
            }

            _requestCultureService.SetRequestCulture(requestedCulture);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
