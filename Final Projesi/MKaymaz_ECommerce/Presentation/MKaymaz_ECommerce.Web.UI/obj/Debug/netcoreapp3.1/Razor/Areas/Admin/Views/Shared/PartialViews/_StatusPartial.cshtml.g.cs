#pragma checksum "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e9a70a7eeac6277078e7836affa5427e8ac4c81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_PartialViews__StatusPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/PartialViews/_StatusPartial.cshtml")]
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
#line 1 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CategoryViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.BrandViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.UserViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CurrencyViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CountryViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.MemberViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.TownViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.LocationViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductImageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Web.UI.Models.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\_ViewImports.cshtml"
using MKaymaz_ECommerce.Common.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9a70a7eeac6277078e7836affa5427e8ac4c81", @"/Areas/Admin/Views/Shared/PartialViews/_StatusPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4f6a0a32880bcf3222b5f5739c0d1dec03742a", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Shared_PartialViews__StatusPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Status>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
 switch (Model)
{
    case Status.None:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-primary\">İşlem Yapılmadı</span>\r\n");
#nullable restore
#line 7 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
    case Status.Active:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-primary\">Aktif</span>\r\n");
#nullable restore
#line 10 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
    case Status.Deleted:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-danger\">Silindi</span>\r\n");
#nullable restore
#line 13 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
    case Status.Updated:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-info\">Güncellendi</span>\r\n");
#nullable restore
#line 16 "C:\Users\Monster\Desktop\Final Projesi\MKaymaz_ECommerce\Presentation\MKaymaz_ECommerce.Web.UI\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Status> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
