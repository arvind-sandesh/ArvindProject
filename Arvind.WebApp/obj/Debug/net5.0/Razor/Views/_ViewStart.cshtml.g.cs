#pragma checksum "D:\Office_Works\ArvindProject\Arvind.WebApp\Views\_ViewStart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd5ee339218205c8babe64d4f3ee1d9c621570d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views__ViewStart), @"mvc.1.0.view", @"/Views/_ViewStart.cshtml")]
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
#line 1 "D:\Office_Works\ArvindProject\Arvind.WebApp\Views\_ViewImports.cshtml"
using Arvind.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Office_Works\ArvindProject\Arvind.WebApp\Views\_ViewImports.cshtml"
using Arvind.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Office_Works\ArvindProject\Arvind.WebApp\Views\_ViewImports.cshtml"
using Arvind.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Office_Works\ArvindProject\Arvind.WebApp\Views\_ViewImports.cshtml"
using Arvind.Entities.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Office_Works\ArvindProject\Arvind.WebApp\Views\_ViewImports.cshtml"
using Arvind.Entities.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Office_Works\ArvindProject\Arvind.WebApp\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Office_Works\ArvindProject\Arvind.WebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd5ee339218205c8babe64d4f3ee1d9c621570d9", @"/Views/_ViewStart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1064a363fad030c2da22043d0b615157f10c5962", @"/Views/_ViewImports.cshtml")]
    public class Views__ViewStart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Office_Works\ArvindProject\Arvind.WebApp\Views\_ViewStart.cshtml"
  
    if (User.Identity.IsAuthenticated)
    {
        Layout = "_LayoutSecure";
    }
    else
    {
        Layout = "_Layout";
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
