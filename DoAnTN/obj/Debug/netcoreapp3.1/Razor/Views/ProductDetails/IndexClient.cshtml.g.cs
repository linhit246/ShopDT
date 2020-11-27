#pragma checksum "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de5c1ac654929016397f3c1b6b74d50ed0cf5937"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductDetails_IndexClient), @"mvc.1.0.view", @"/Views/ProductDetails/IndexClient.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de5c1ac654929016397f3c1b6b74d50ed0cf5937", @"/Views/ProductDetails/IndexClient.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94780be9c1e63257ef26cd661e253caf48a5987c", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductDetails_IndexClient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DoAnTN.Models.ProductDetail>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("32px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("32px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-radius: 50%; margin-top: 5px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Comments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
  
    ViewData["Title"] = "IndexClient";
    Layout = "~/Views/Shared/_LayoutDetail.cshtml";
    var list = (List<ProductDetail>)ViewBag.ListProductDetail;
    var comment = ViewBag.Comments;
    var prod = (Product)ViewBag.Product;
    var specifications = ViewBag.Specifications;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .pb-cmnt-container {
        font-family: Lato;
        margin-top: 100px;
    }

    .pb-cmnt-textarea {
        resize: none;
        padding: 20px;
        height: 130px;
        width: 100%;
        border: 1px solid #F2F2F2;
    }
</style>
<div class=""content"">
    <div class=""row"">
        <div class=""col-8"">
            <div class=""product-details"">
                <div class=""grid images_3_of_2"">
                    <div id=""container"">
                        <div id=""products_example"">
                            <div id=""products"">
                                <div class=""slides_container"" style=""min-height: 360px; text-align: center"">
                                    <a");
            BeginWriteAttribute("href", " href=\"", 1073, "\"", 1121, 1);
#nullable restore
#line 33 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
WriteAttributeValue("", 1080, Url.Content("~/image/" + prod.ImagePath), 1080, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"><img style=\"margin-left: -50px\" id=\"pdImage\"");
            BeginWriteAttribute("src", " src=\"", 1183, "\"", 1230, 1);
#nullable restore
#line 33 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
WriteAttributeValue("", 1189, Url.Content("~/image/" + prod.ImagePath), 1189, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1231, "\"", 1237, 0);
            EndWriteAttribute();
            WriteLiteral(@" /></a>
                                    <div class=""clear""></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""desc span_3_of_2"">
                    <h2 style=""font-weight: bolder; font-size: 2.5em"">");
#nullable restore
#line 41 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                                                 Write(prod.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <div class=\"price\">\r\n                        <p><span style=\"font-size: 2em\">");
#nullable restore
#line 43 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                                   Write(prod.SellCost.ToString("#,###"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ₫</span></p>
                    </div>
                    <div class=""available"">
                        <ul>
                            <li>
                                <span style=""font-size: large"">Màu: </span>
                                <select id=""color"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de5c1ac654929016397f3c1b6b74d50ed0cf59378827", async() => {
                WriteLiteral("Chọn màu");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 51 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                     foreach (var item in list)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de5c1ac654929016397f3c1b6b74d50ed0cf593710722", async() => {
#nullable restore
#line 53 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                                                                                 Write(item.ProductColor);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 53 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
AddHtmlAttributeValue("", 2253, item.Id, 2253, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "name", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 53 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
AddHtmlAttributeValue("", 2286, item.ImagePath, 2286, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 54 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </select>
                            </li>
                        </ul>
                    </div>
                    <div class=""share-desc"">
                        <a id=""buyNow"" class=""btn btn-primary btn-lg"">MUA NGAY</a>
                        <div class=""clear""></div>
                    </div>
                    <script type=""text/javascript"">
                        $(document).ready(function () {
                            $(""#color"").mouseout(function () {
                                var id = $(""#color"").val().toString();
                                var url = ""http://localhost:53875/Cart/BuyProducts/"" + id;
                                $(""#buyNow"").attr(""href"", url);
                            });
                            $(""#color"").change(function () {
                                var link = $(this).find(""option:selected"").attr(""name"");
                                var src = ");
#nullable restore
#line 72 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                     Write(Url.Content("~/image/"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" + link;
                                $(""#pdImage"").attr(""src"", src);
                            });
                            $(""#buyNow"").click(function () {
                                if ($(this).attr(""href"") == null) {
                                    alert(""Vui lòng chọn màu"");
                                }
                            });
                        });
                    </script>
                </div>
                <div class=""clear""></div>
            </div>
");
#nullable restore
#line 85 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
             if (comment != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-12\" style=\"padding: 0; margin-bottom: 20px\">\r\n                <div class=\"modal-content\" style=\"padding: 20px\">\r\n");
#nullable restore
#line 89 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                     foreach (var item in comment)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"d-flex align-content-start\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "de5c1ac654929016397f3c1b6b74d50ed0cf593716129", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 92 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                          WriteLiteral(Url.Content("~/image/user/" + item.User.Avatar));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 92 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <div class=\"col\">\r\n                                <strong>");
#nullable restore
#line 94 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                   Write(item.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 94 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                                        Write(item.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong><span> - ");
#nullable restore
#line 94 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                                                                              Write(String.Format("{0:dd/MM/yyyy}", item.CommentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <p>");
#nullable restore
#line 95 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                              Write(item.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 98 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n");
#nullable restore
#line 101 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card card-info\">\r\n                <div class=\"card-block\" style=\"padding: 10px\">\r\n                    <strong>Nhận xét của bạn</strong>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de5c1ac654929016397f3c1b6b74d50ed0cf593720282", async() => {
                WriteLiteral(@"
                        <textarea name=""content"" placeholder=""Viết bình luận của bạn ở đây!"" class=""pb-cmnt-textarea"" style=""outline: none; padding: 5px"" maxlength=""500""></textarea>
                        <button class=""btn btn-primary float-right"" type=""submit"">Gửi bình luận</button>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 105 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                                                                                        WriteLiteral(prod.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <div class=\"clear\"></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 113 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
         if (specifications != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-4\" style=\"float: right\">\r\n                <div class=\"categories\">\r\n                    <h3 style=\"margin-bottom: 0\">Thông số kĩ thuật</h3>\r\n                    <table class=\"table table-striped\" style=\"margin-bottom: 0\">\r\n\r\n");
#nullable restore
#line 120 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.Storage != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Bộ nhớ trong:</th>\r\n                                <td>");
#nullable restore
#line 124 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.Storage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 126 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 127 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.Ram != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>RAM:</th>\r\n                                <td>");
#nullable restore
#line 131 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.Ram);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 133 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 134 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.Fcamera != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Cam chính:</th>\r\n                                <td>");
#nullable restore
#line 138 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.Fcamera);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 140 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 141 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.Scamera != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Cam phụ:</th>\r\n                                <td>");
#nullable restore
#line 145 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.Scamera);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 147 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 148 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.Cpu != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>CPU:</th>\r\n                                <td>");
#nullable restore
#line 152 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.Cpu);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 154 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 155 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.Resolution != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Độ phân giải:</th>\r\n                                <td>");
#nullable restore
#line 159 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.Resolution);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 161 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 162 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.Battery != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Dung lượng Pin:</th>\r\n                                <td>");
#nullable restore
#line 166 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.Battery);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 168 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 169 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.Os != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Hệ điều hành:</th>\r\n                                <td>");
#nullable restore
#line 173 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.Os);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 175 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 176 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.ScreenSize != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Kích thước màn hình:</th>\r\n                                <td>");
#nullable restore
#line 180 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.ScreenSize);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 182 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 183 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.SimNumber != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Thẻ Sim:</th>\r\n                                <td>");
#nullable restore
#line 187 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.SimNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 189 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 190 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.FastCharge != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Sạc nhanh:</th>\r\n                                <td>");
#nullable restore
#line 194 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.FastCharge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 196 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 197 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                         if (@specifications.Sdcard != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Thẻ nhớ:</th>\r\n                                <td>");
#nullable restore
#line 201 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                               Write(specifications.Sdcard);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 203 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        \r\n                    </table>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 208 "D:\DoAnTN\DoAnTN\Views\ProductDetails\IndexClient.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DoAnTN.Models.ProductDetail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
