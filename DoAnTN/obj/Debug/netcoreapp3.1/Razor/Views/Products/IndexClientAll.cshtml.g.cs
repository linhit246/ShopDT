#pragma checksum "D:\DoAnTN\DoAnTN\Views\Products\IndexClientAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2cbf5c176db31abe028bf8f0b7fa6247e2f71cee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_IndexClientAll), @"mvc.1.0.view", @"/Views/Products/IndexClientAll.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\DoAnTN\DoAnTN\Views\_ViewImports.cshtml"
using DoAnTN;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DoAnTN\DoAnTN\Views\_ViewImports.cshtml"
using DoAnTN.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cbf5c176db31abe028bf8f0b7fa6247e2f71cee", @"/Views/Products/IndexClientAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94780be9c1e63257ef26cd661e253caf48a5987c", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_IndexClientAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DoAnTN.Models.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\DoAnTN\DoAnTN\Views\Products\IndexClientAll.cshtml"
  
    ViewData["Title"] = "IndexClient";
    Layout = "~/Views/Shared/_LayoutClient.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content_top"" style=""display: flex; align-items: center; justify-content: space-between; padding: 10px 0 0 10px; margin-bottom: 10px"">
    <h4 style=""font-weight: bold"">Sản phẩm mới</h4>
    <p style=""margin-right: 10px""><a href=""#"">Xem tất cả</a></p>
");
            WriteLiteral("</div>\r\n<div class=\"row\">\r\n");
#nullable restore
#line 12 "D:\DoAnTN\DoAnTN\Views\Products\IndexClientAll.cshtml"
     foreach (var item in Model)
    {
        var url = "/ProductDetails/IndexClient/" + item.Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-3 col-sm-6 col-12\">\r\n            <div class=\"card card-product mb-3\" style=\"overflow: hidden;\">\r\n                <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 738, "\"", 785, 1);
#nullable restore
#line 17 "D:\DoAnTN\DoAnTN\Views\Products\IndexClientAll.cshtml"
WriteAttributeValue("", 744, Url.Content("~/image/" + item.ImagePath), 744, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 786, "\"", 802, 1);
#nullable restore
#line 17 "D:\DoAnTN\DoAnTN\Views\Products\IndexClientAll.cshtml"
WriteAttributeValue("", 792, item.Name, 792, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 19 "D:\DoAnTN\DoAnTN\Views\Products\IndexClientAll.cshtml"
                                      Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text\" style=\"color: red\">");
#nullable restore
#line 20 "D:\DoAnTN\DoAnTN\Views\Products\IndexClientAll.cshtml"
                                                       Write(item.SellCost.ToString("#,###"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₫</p>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1029, "\"", 1040, 1);
#nullable restore
#line 21 "D:\DoAnTN\DoAnTN\Views\Products\IndexClientAll.cshtml"
WriteAttributeValue("", 1036, url, 1036, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Mua Ngay</a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 25 "D:\DoAnTN\DoAnTN\Views\Products\IndexClientAll.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DoAnTN.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
