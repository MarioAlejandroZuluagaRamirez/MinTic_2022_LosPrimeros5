#pragma checksum "C:\Users\mazul\Desktop\Desarrollo de Software MinTic\C#\Projecto\SICAU\SICAU.App\SICAU.App.Frontend\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03d5ca7e56f11042f8fac32ef4e5892d34d8ea36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SICAU.App.Frontend.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace SICAU.App.Frontend.Pages
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
#line 1 "C:\Users\mazul\Desktop\Desarrollo de Software MinTic\C#\Projecto\SICAU\SICAU.App\SICAU.App.Frontend\Pages\_ViewImports.cshtml"
using SICAU.App.Frontend;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03d5ca7e56f11042f8fac32ef4e5892d34d8ea36", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"696e780f3b9bb690caa9c737c7e570ba1229e39a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\mazul\Desktop\Desarrollo de Software MinTic\C#\Projecto\SICAU\SICAU.App\SICAU.App.Frontend\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n");
            WriteLiteral("    <h1 class=\"display-4\">Bienvenido!!!</h1>\r\n    <h1 class=\"display-4\">Proyecto de Desarrollo de Software</h1>\r\n    <h1 class=\"display-4\">MinTic 2022</h1>\r\n");
            WriteLiteral("</div>\r\n\r\n");
#nullable restore
#line 15 "C:\Users\mazul\Desktop\Desarrollo de Software MinTic\C#\Projecto\SICAU\SICAU.App\SICAU.App.Frontend\Pages\Index.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-sm\">\r\n");
#nullable restore
#line 18 "C:\Users\mazul\Desktop\Desarrollo de Software MinTic\C#\Projecto\SICAU\SICAU.App\SICAU.App.Frontend\Pages\Index.cshtml"
         foreach (var claim in User.Claims)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\mazul\Desktop\Desarrollo de Software MinTic\C#\Projecto\SICAU\SICAU.App\SICAU.App.Frontend\Pages\Index.cshtml"
               Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\mazul\Desktop\Desarrollo de Software MinTic\C#\Projecto\SICAU\SICAU.App\SICAU.App.Frontend\Pages\Index.cshtml"
               Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 24 "C:\Users\mazul\Desktop\Desarrollo de Software MinTic\C#\Projecto\SICAU\SICAU.App\SICAU.App.Frontend\Pages\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 26 "C:\Users\mazul\Desktop\Desarrollo de Software MinTic\C#\Projecto\SICAU\SICAU.App\SICAU.App.Frontend\Pages\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
