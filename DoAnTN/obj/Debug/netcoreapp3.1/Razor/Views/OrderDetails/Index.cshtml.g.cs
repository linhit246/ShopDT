#pragma checksum "D:\DoAnTN\DoAnTN\Views\OrderDetails\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19da00b090145673acaefbb44a47b8b2ce78b662"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OrderDetails_Index), @"mvc.1.0.view", @"/Views/OrderDetails/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19da00b090145673acaefbb44a47b8b2ce78b662", @"/Views/OrderDetails/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94780be9c1e63257ef26cd661e253caf48a5987c", @"/Views/_ViewImports.cshtml")]
    public class Views_OrderDetails_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DoAnTN.Models.OrderDetail>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\DoAnTN\DoAnTN\Views\OrderDetails\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Chi tiết đơn hàng</h2>

<table class=""table table-bordered"" style=""text-align: center"">
    <thead>
        <tr>
            <th style=""font-weight: bold"">
                Mã đơn hàng
            </th>
            <th style=""font-weight: bold"">
                Mã sản phẩm
            </th>
            <th style=""font-weight: bold"">
                Số lượng
            </th>
            <th style=""font-weight: bold"">
                Tổng tiền
            </th>
            <th style=""font-weight: bold"">
                Ngày cập nhật
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 31 "D:\DoAnTN\DoAnTN\Views\OrderDetails\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "D:\DoAnTN\DoAnTN\Views\OrderDetails\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Order.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "D:\DoAnTN\DoAnTN\Views\OrderDetails\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductDetail.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "D:\DoAnTN\DoAnTN\Views\OrderDetails\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "D:\DoAnTN\DoAnTN\Views\OrderDetails\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "D:\DoAnTN\DoAnTN\Views\OrderDetails\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastUpdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 49 "D:\DoAnTN\DoAnTN\Views\OrderDetails\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DoAnTN.Models.OrderDetail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
