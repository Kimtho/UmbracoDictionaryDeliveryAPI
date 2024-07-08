using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Umbraco.Extensions;
namespace UmbracoDictionaryDeliveryAPI.Swagger;

internal abstract class SwaggerFilterBase<TBaseController>
    where TBaseController : Microsoft.AspNetCore.Mvc.Controller
{
    protected bool CanApply(OperationFilterContext context)
        => CanApply(context.MethodInfo);

    protected bool CanApply(ParameterFilterContext context)
        => CanApply(context.ParameterInfo.Member);

    private bool CanApply(MemberInfo member)
        => member.DeclaringType?.Implements<TBaseController>() is true;
}

