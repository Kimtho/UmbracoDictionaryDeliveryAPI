using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Umbraco.Cms.Api.Delivery.Controllers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using UmbracoDictionaryDeliveryAPI.Controller.Attribute;

namespace UmbracoDictionaryDeliveryAPI.Controller;

[ApiVersion("2.0")]
[DeliveryApiAccess]
[VersionedDeliveryApiRoute("dictionary")]
[ApiExplorerSettings(GroupName = "Dictionary")]
[LocalizeFromAcceptLanguageHeader]
[ValidateStartItem]
[OutputCache(PolicyName = Constants.DeliveryApi.OutputCache.ContentCachePolicy)]
public class DictionaryController(IDictionaryItemService dictionaryItemService, IRequestCultureService requestCultureService) : DeliveryApiControllerBase
{
    [HttpGet]
    [Route("{key}")]
    public async Task<IActionResult> ByKey(string key)
    {
        var culture = requestCultureService.GetRequestedCulture();
        var dictionary = await dictionaryItemService.GetAsync(key);
        if (dictionary == null)
        {
            return NotFound();
        }
        return Ok(GetDictionaryItemUrl(dictionary, culture));
    }
    [HttpGet]
    [Route("Items/")]
    public async Task<IActionResult> GetAll()
    {
        var culture = requestCultureService.GetRequestedCulture();
        var rootDictionaries = await dictionaryItemService.GetAtRootAsync();
        var result = new List<IDictionaryItem>();
        foreach (IDictionaryItem item in rootDictionaries)
        {
            result.Add(item);
            result.AddRange(await dictionaryItemService.GetDescendantsAsync(item.Key));
        }
        var response = result
            .Select(x => GetDictionaryItemUrl(x, culture))
                .ToDictionary();
        return Ok(response);

    }

    [HttpGet]
    [Route("Items/{key}")]
    public async Task<IActionResult> GetALLBelowKey(string key)
    {
        var culture = requestCultureService.GetRequestedCulture();
        var dictionary = await dictionaryItemService.GetAsync(key);
        if (dictionary == null)
        {
            return NotFound();
        }

        var result = await dictionaryItemService.GetDescendantsAsync(dictionary.Key);
        var response = result
           .Select(x => GetDictionaryItemUrl(x, culture))
               .ToDictionary();
        return Ok(response);
    }

    private KeyValuePair<string, string?> GetDictionaryItemUrl(IDictionaryItem dictionaryItem, string? culture)
    {
        Func<IDictionaryTranslation, bool> predict = culture == null
            ? x => true
            : x => x.LanguageIsoCode == culture;
        var translation = dictionaryItem.Translations.FirstOrDefault(predict);
        string? value = null;
        if (translation != null)
        {
            value = translation.Value;
        }
        return new KeyValuePair<string, string?>(dictionaryItem.ItemKey, value);



    }
}
