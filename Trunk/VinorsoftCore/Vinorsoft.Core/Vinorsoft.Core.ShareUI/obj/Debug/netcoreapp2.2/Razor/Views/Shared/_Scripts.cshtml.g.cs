#pragma checksum "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7951155345f37a55b764ca92743e0789bf3a6d8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Scripts), @"mvc.1.0.view", @"/Views/Shared/_Scripts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Scripts.cshtml", typeof(AspNetCore.Views_Shared__Scripts))]
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
#line 2 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#line 3 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\_ViewImports.cshtml"
using Vinorsoft.Core.DTO;

#line default
#line hidden
#line 4 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\_ViewImports.cshtml"
using Vinorsoft.Core.Resx;

#line default
#line hidden
#line 5 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\_ViewImports.cshtml"
using Vinorsoft.Core.Domain;

#line default
#line hidden
#line 6 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\_ViewImports.cshtml"
using Vinorsoft.Core.App;

#line default
#line hidden
#line 7 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\_ViewImports.cshtml"
using Vinorsoft.Core.App.Context;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7951155345f37a55b764ca92743e0789bf3a6d8c", @"/Views/Shared/_Scripts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eede0615abfda23780cdbd81aa0d7c1a5987cc67", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Scripts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
  
    var controllerName = ViewContext.RouteData.Values["controller"].ToString();
    var areaName = ViewContext.RouteData.Values["area"]?.ToString();
    var returnUrl = Context.Request.Query["returnUrl"];
    if (string.IsNullOrEmpty(returnUrl))
    {
         returnUrl = Context.Request.Query["ReturnUrl"];
    }

#line default
#line hidden
            BeginContext(329, 54, true);
            WriteLiteral("<script>\r\n    function goBack() {\r\n        var url = \'");
            EndContext();
            BeginContext(384, 9, false);
#line 12 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
              Write(returnUrl);

#line default
#line hidden
            EndContext();
            BeginContext(393, 70, true);
            WriteLiteral("\';\r\n        if (url == null || url.length <= 0) {\r\n            url = \'");
            EndContext();
            BeginContext(464, 60, false);
#line 14 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
              Write(Url.Action("Index", controllerName, new { Area = areaName }));

#line default
#line hidden
            EndContext();
            BeginContext(524, 150, true);
            WriteLiteral("\'\r\n        }\r\n        window.location.href = url;\r\n    }\r\n\r\n    function onUpdateItem(e) {\r\n        e.cancel = true;\r\n        window.location.href = \'");
            EndContext();
            BeginContext(675, 78, false);
#line 21 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
                           Write(Url.Action("Update" + controllerName, controllerName, new { Area = areaName }));

#line default
#line hidden
            EndContext();
            BeginContext(753, 287, true);
            WriteLiteral(@"/' + e.key + '?ReturnUrl=' + window.location.pathname;
    }

    function toolbar_preparing(e) {
        e.toolbarOptions.items.unshift({
            location: ""after"",
            widget: ""dxButton"",
            options: {
                icon: ""plus"",
                hint: '");
            EndContext();
            BeginContext(1041, 33, false);
#line 30 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
                  Write(Html.Raw(Resources.Button_AddNew));

#line default
#line hidden
            EndContext();
            BeginContext(1074, 88, true);
            WriteLiteral("\',\r\n                onClick: function () {\r\n                    window.location.href = \'");
            EndContext();
            BeginContext(1163, 75, false);
#line 32 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
                                       Write(Url.Action("New"+ controllerName, controllerName , new { Area = areaName }));

#line default
#line hidden
            EndContext();
            BeginContext(1238, 331, true);
            WriteLiteral(@"?ReturnUrl=' + window.location.pathname;
                }
            }
        })
    }

    function toolbar_preparing_hasdownload(e) {
        e.toolbarOptions.items.unshift({
            location: ""after"",
            widget: ""dxButton"",
            options: {
                icon: ""plus"",
                hint: """);
            EndContext();
            BeginContext(1570, 33, false);
#line 44 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
                  Write(Html.Raw(Resources.Button_AddNew));

#line default
#line hidden
            EndContext();
            BeginContext(1603, 88, true);
            WriteLiteral("\",\r\n                onClick: function () {\r\n                    window.location.href = \'");
            EndContext();
            BeginContext(1692, 75, false);
#line 46 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
                                       Write(Url.Action("New"+ controllerName, controllerName , new { Area = areaName }));

#line default
#line hidden
            EndContext();
            BeginContext(1767, 241, true);
            WriteLiteral("?ReturnUrl=\' + window.location.pathname\r\n                }\r\n            }\r\n        },{\r\n            location: \"after\",\r\n            widget: \"dxButton\",\r\n            options: {\r\n                icon: \"fa fa-download\",\r\n                hint: \"");
            EndContext();
            BeginContext(2009, 35, false);
#line 54 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
                  Write(Html.Raw(Resources.Button_Download));

#line default
#line hidden
            EndContext();
            BeginContext(2044, 88, true);
            WriteLiteral("\",\r\n                onClick: function () {\r\n                    window.location.href = \'");
            EndContext();
            BeginContext(2133, 82, false);
#line 56 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
                                       Write(Url.Action("DownloadTemplate", "Import" + controllerName, new { Area = "Import" }));

#line default
#line hidden
            EndContext();
            BeginContext(2215, 239, true);
            WriteLiteral("?ReturnUrl=\' + window.location.pathname\r\n                }\r\n            }\r\n        },{\r\n            location: \"after\",\r\n            widget: \"dxButton\",\r\n            options: {\r\n                icon: \"fa fa-upload\",\r\n                hint: \"");
            EndContext();
            BeginContext(2455, 33, false);
#line 64 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
                  Write(Html.Raw(Resources.Button_Import));

#line default
#line hidden
            EndContext();
            BeginContext(2488, 88, true);
            WriteLiteral("\",\r\n                onClick: function () {\r\n                    window.location.href = \'");
            EndContext();
            BeginContext(2577, 71, false);
#line 66 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
                                       Write(Url.Action("Index", "Import" + controllerName, new { Area = "Import" }));

#line default
#line hidden
            EndContext();
            BeginContext(2648, 234, true);
            WriteLiteral("?ReturnUrl=\' + window.location.pathname\r\n                }\r\n            }\r\n        })\r\n    }\r\n\r\n    function onInitNewRow(e) {\r\n        e.data[\"Id\"] = uuidv4();\r\n        e.data[\"Created\"] = new Date();\r\n        e.data[\"CreatedBy\"] = \'");
            EndContext();
            BeginContext(2883, 43, false);
#line 75 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Views\Shared\_Scripts.cshtml"
                          Write(LoginContext.Instance.CurrentUser?.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(2926, 20, true);
            WriteLiteral("\';\r\n    }\r\n</script>");
            EndContext();
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