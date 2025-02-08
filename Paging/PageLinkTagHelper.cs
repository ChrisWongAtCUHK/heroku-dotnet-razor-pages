﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Dynamic;

namespace DotNetRazorPages.Paging;

[HtmlTargetElement("div", Attributes = "page-model")]
public class PageLinkTagHelper : TagHelper
{
    private IUrlHelperFactory _urlHelperFactory;

    public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; }

    public PagingInfo? PageModel { get; set; }

    public string? PageName { get; set; }

    /*Accepts all attributes that are page-other-* like page-other-category="@Model.allTotal" page-other-some="@Model.allTotal"*/
    [HtmlAttributeName(DictionaryAttributePrefix = "page-other-")]
    public Dictionary<string, object> PageOtherValues { get; set; } = new Dictionary<string, object>();

    public bool PageClassesEnabled { get; set; } = false;

    public string? PageClass { get; set; }

    public string? PageClassSelected { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
#pragma warning disable CS8604 // Possible null reference argument.
        IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
#pragma warning restore CS8604 // Possible null reference argument.
        TagBuilder result = new TagBuilder("div");
        string anchorInnerHtml = "";

        for (int i = 1; i <= PageModel!.TotalPages; i++)
        {
            TagBuilder tag = new TagBuilder("a");
            anchorInnerHtml = AnchorInnerHtml(i, PageModel);

            if (anchorInnerHtml == "..")
                tag.Attributes["href"] = "#";
            else if (PageOtherValues.Keys.Count != 0)
                tag.Attributes["href"] = urlHelper.Page(PageName, AddDictionaryToQueryString(i));
            else
                tag.Attributes["href"] = urlHelper.Page(PageName, new { id = i });

            if (PageClassesEnabled)
            {
                tag.AddCssClass(PageClass ?? "");
                string? cssClass = i == PageModel.CurrentPage ? PageClassSelected : "" ;
                tag.AddCssClass(cssClass ?? "");
            }
            tag.InnerHtml.Append(anchorInnerHtml);
            if (anchorInnerHtml != "")
                result.InnerHtml.AppendHtml(tag);
        }
        output.Content.AppendHtml(result.InnerHtml);
    }

    public IDictionary<string, object> AddDictionaryToQueryString(int i)
    {
        object? routeValues = null;
        var dict = (routeValues != null) ? new RouteValueDictionary(routeValues) : new RouteValueDictionary();
        dict.Add("id", i);
        foreach (string key in PageOtherValues.Keys)
        {
            dict.Add(key, PageOtherValues[key]);
        }

        var expandoObject = new ExpandoObject();
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        var expandoDictionary = (IDictionary<string, object>)expandoObject;
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        foreach (var keyValuePair in dict)
        {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            expandoDictionary.Add(keyValuePair);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        }

        return expandoDictionary;
    }

    public static string AnchorInnerHtml(int i, PagingInfo pagingInfo)
    {
        string anchorInnerHtml = "";
        if (pagingInfo.TotalPages <= 10)
            anchorInnerHtml = i.ToString();
        else
        {
            if (pagingInfo.CurrentPage <= 5)
            {
                if ((i <= 8) || (i == pagingInfo.TotalPages))
                    anchorInnerHtml = i.ToString();
                else if (i == pagingInfo.TotalPages - 1)
                    anchorInnerHtml = "..";
            }
            else if ((pagingInfo.CurrentPage > 5) && (pagingInfo.TotalPages - pagingInfo.CurrentPage >= 5))
            {
                if ((i == 1) || (i == pagingInfo.TotalPages) || ((pagingInfo.CurrentPage - i >= -3) && (pagingInfo.CurrentPage - i <= 3)))
                    anchorInnerHtml = i.ToString();
                else if ((i == pagingInfo.CurrentPage - 4) || (i == pagingInfo.CurrentPage + 4))
                    anchorInnerHtml = "..";
            }
            else if (pagingInfo.TotalPages - pagingInfo.CurrentPage < 5)
            {
                if ((i == 1) || (pagingInfo.TotalPages - i <= 7))
                    anchorInnerHtml = i.ToString();
                else if (pagingInfo.TotalPages - i == 8)
                    anchorInnerHtml = "..";
            }
        }
        return anchorInnerHtml;
    }
}
