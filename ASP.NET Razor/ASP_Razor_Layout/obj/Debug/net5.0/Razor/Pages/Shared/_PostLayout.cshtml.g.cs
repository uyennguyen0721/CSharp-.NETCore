#pragma checksum "D:\.NET Core Projects\CSharp-.NETCore\ASP_Razor_Layout\Pages\Shared\_PostLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fdb607442cc6dda855814338c6d529b58f5b7c7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ASP_Razor_Layout.Pages.Shared.Pages_Shared__PostLayout), @"mvc.1.0.view", @"/Pages/Shared/_PostLayout.cshtml")]
namespace ASP_Razor_Layout.Pages.Shared
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
#line 1 "D:\.NET Core Projects\CSharp-.NETCore\ASP_Razor_Layout\Pages\_ViewImports.cshtml"
using ASP_Razor_Layout;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdb607442cc6dda855814338c6d529b58f5b7c7f", @"/Pages/Shared/_PostLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"208afb0effaca20e7b9049be2a0eba60eaf4eb84", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__PostLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\.NET Core Projects\CSharp-.NETCore\ASP_Razor_Layout\Pages\Shared\_PostLayout.cshtml"
   
    Layout = "_MyLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-3 bg-danger\">\r\n        MENU TRÁI\r\n    </div>\r\n    <div class=\"col-9\">\r\n        ");
#nullable restore
#line 11 "D:\.NET Core Projects\CSharp-.NETCore\ASP_Razor_Layout\Pages\Shared\_PostLayout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
