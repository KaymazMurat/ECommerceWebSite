#pragma checksum "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\Home\Post.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f80b4612b5dfbe2d256ea394dfbfd110b833984"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Post), @"mvc.1.0.view", @"/Views/Home/Post.cshtml")]
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
#line 1 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Models.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CategoryViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductImageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.BrandViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.UserViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CreateCartItemViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ShippingAddressViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f80b4612b5dfbe2d256ea394dfbfd110b833984", @"/Views/Home/Post.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ec72d73fd2da2ef79b74cc502dd33f8c69f745a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Post : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\Home\Post.cshtml"
  
    ViewData["Title"] = "Post";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-lg-6 col-md-6 col-sm-12 col-12\">\r\n        <div class=\"product-details-img\">\r\n            <div class=\"pl-20\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 283, "\"", 303, 1);
#nullable restore
#line 11 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\Home\Post.cshtml"
WriteAttributeValue("", 289, Model.Barcode, 289, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 304, "\"", 310, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-lg-6 col-md-6 col-sm-12 col-12\">\r\n        <div class=\"product-single__meta\">\r\n            <h2 class=\"product-single__title\">");
#nullable restore
#line 17 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\Home\Post.cshtml"
                                         Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <div class=\"prInfoRow\">\r\n                <div class=\"product-stock\"> <span class=\"instock \">In Stock</span> <span class=\"outstock hide\">Unavailable</span> </div>\r\n                <div class=\"product-sku\">SKU: <span class=\"variant-sku\">");
#nullable restore
#line 20 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\Home\Post.cshtml"
                                                                   Write(Model.Sku);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></div>
            </div>
            <p class=""product-single__price product-single__price-product-template"">
                <span class=""visually-hidden"">Regular price</span>
                <s id=""ComparePrice-product-template""><span class=""money"">");
#nullable restore
#line 24 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\Home\Post.cshtml"
                                                                     Write(Model.Price1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></s>\r\n                <span class=\"product-price__price product-price__price-product-template product-price__sale product-price__sale--single\">\r\n                    <span id=\"ProductPrice-product-template\"><span class=\"money\">");
#nullable restore
#line 26 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\Home\Post.cshtml"
                                                                            Write(Model.Price1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></span>\r\n                </span>\r\n            </p>\r\n            <div class=\"product-single__description rte\">\r\n                ");
#nullable restore
#line 30 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\Home\Post.cshtml"
           Write(Model.MetaDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div id=\"product_form_10508262282\"  class=\"product-form product-form-product-template hidedropdown\">\r\n\r\n                <!-- Product Action -->\r\n                <div class=\"product-action clearfix\">\r\n");
            WriteLiteral("                    <div class=\"product-form__item--submit\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f80b4612b5dfbe2d256ea394dfbfd110b83398410834", async() => {
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1f80b4612b5dfbe2d256ea394dfbfd110b83398411121", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 48 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Views\Home\Post.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            <button class=\"btn btn-addto-cart\" type=\"submit\"");
                BeginWriteAttribute("title", " title=\"", 2696, "\"", 2704, 0);
                EndWriteAttribute();
                WriteLiteral(">Add Cart</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <!-- End Product Action -->\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
