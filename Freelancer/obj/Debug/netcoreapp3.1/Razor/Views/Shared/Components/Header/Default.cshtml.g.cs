#pragma checksum "C:\Users\user\source\repos\Freelancer\Freelancer\Views\Shared\Components\Header\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aeb732e7146e65afba4232ab2aae90e81851e49d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Header_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Header/Default.cshtml")]
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
#line 1 "C:\Users\user\source\repos\Freelancer\Freelancer\Views\_ViewImports.cshtml"
using Freelancer.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aeb732e7146e65afba4232ab2aae90e81851e49d", @"/Views/Shared/Components/Header/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15b6ab2c4b23e8e2b09e73b11150aedcd186e477", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Header_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- header start -->
<header>
    <nav>
        <div class=""container"">
            <div class=""row align-items-center "">
                <div class=""col-6 col-sm-6 col-md-6 col-lg-6"">
                    <div class=""nav-logo"">
                        <a href=""#"">");
#nullable restore
#line 17 "C:\Users\user\source\repos\Freelancer\Freelancer\Views\Shared\Components\Header\Default.cshtml"
                               Write(Model.Setting.HeaderLogo);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                    </div>
                </div>
                <div class=""col-6 col-sm-6 col-md-6 col-lg-6"">
                    <div class=""nav-menu "">
                        <ul class=""d-flex list-unstyled justify-content-end m-0 p-0"">
                            <li><a href=""#"">portfolio</a></li>
                            <li class=""ms-5""><a href=""#"">about</a></li>
                            <li class=""ms-5""><a href=""#"">contact</a></li>
                            <li class=""drop ms-5"" style=""position:relative;"">
                                <a href=""#""><i class=""fa-solid fa-user""></i></a>
                                <ul class=""dropdown list-unstyled"" style=""position:absolute;background-color:#0094ff;height:100px;width:100px;padding:10px "">
");
#nullable restore
#line 29 "C:\Users\user\source\repos\Freelancer\Freelancer\Views\Shared\Components\Header\Default.cshtml"
                                     if (User.Identity.IsAuthenticated)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><a style=\"text-transform:capitalize\" href=\"#\">");
#nullable restore
#line 31 "C:\Users\user\source\repos\Freelancer\Freelancer\Views\Shared\Components\Header\Default.cshtml"
                                                                                      Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
            WriteLiteral("                                        <li><a style=\"text-transform:capitalize\"  href=\"#\">Logout</a></li>\r\n");
#nullable restore
#line 35 "C:\Users\user\source\repos\Freelancer\Freelancer\Views\Shared\Components\Header\Default.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><a style=\"text-transform:capitalize\"  href=\"#\" >Register</a></li>\r\n                                        <li><a style=\"text-transform:capitalize\"  href=\"#\" >Login</a></li>\r\n");
#nullable restore
#line 40 "C:\Users\user\source\repos\Freelancer\Freelancer\Views\Shared\Components\Header\Default.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </ul>
                            </li>
                        </ul>
                    </div>
                    <div class=""bar justify-content-end"">
                        <i class=""fa-solid fa-bars""></i>
                    </div>
                </div>
            </div>

        </div>
        <div class=""navbar d-none"">
            <div class=""close"">
                <i class=""fa-solid fa-xmark d-flex justify-content-end""></i>

            </div>
            <ul class=""m-0 p-0 list-unstyled"">

                <li><a href=""#"">portfolio</a></li>
                <li><a href=""#"">about</a></li>
                <li><a href=""#"">contact</a></li>
            </ul>
        </div>
    </nav>
</header>
<!-- header end -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeVM> Html { get; private set; }
    }
}
#pragma warning restore 1591