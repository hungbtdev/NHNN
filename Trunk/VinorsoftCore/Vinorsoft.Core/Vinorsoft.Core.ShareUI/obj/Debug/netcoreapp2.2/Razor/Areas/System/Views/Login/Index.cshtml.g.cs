#pragma checksum "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17b1f46fd5ef6565346b7dff8342c39cb2b0dd2a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_System_Views_Login_Index), @"mvc.1.0.view", @"/Areas/System/Views/Login/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/System/Views/Login/Index.cshtml", typeof(AspNetCore.Areas_System_Views_Login_Index))]
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
#line 2 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#line 3 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using Vinorsoft.Core.DTO;

#line default
#line hidden
#line 4 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using Vinorsoft.Core.Resx;

#line default
#line hidden
#line 5 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using Vinorsoft.Core.Domain;

#line default
#line hidden
#line 6 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using Vinorsoft.Core.App;

#line default
#line hidden
#line 7 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using Vinorsoft.Core.App.Context;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17b1f46fd5ef6565346b7dff8342c39cb2b0dd2a", @"/Areas/System/Views/Login/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e89d903c5125a6a79e61c03c342c851b58031aab", @"/Areas/System/Views/_ViewImports.cshtml")]
    public class Areas_System_Views_Login_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LoginDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
  
    Layout = "_AuthLayout";

#line default
#line hidden
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(55, 52, true);
            WriteLiteral("<style>\r\n    body {\r\n        background-image: url(\'");
            EndContext();
            BeginContext(108, 77, false);
#line 8 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
                          Write(Url.Action("ImageWithCode", "Galery", new { code="LoginBg", Area = "Media" }));

#line default
#line hidden
            EndContext();
            BeginContext(185, 129, true);
            WriteLiteral("\') !important;\r\n        background-repeat: no-repeat !important;\r\n        background-size: cover !important;\r\n    }\r\n</style>\r\n\r\n");
            EndContext();
            BeginContext(315, 33, false);
#line 14 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
Write(await Html.PartialAsync("_Style"));

#line default
#line hidden
            EndContext();
            BeginContext(348, 33, true);
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    ");
            EndContext();
            BeginContext(382, 38, false);
#line 17 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
Write(await Html.PartialAsync("_ErrorAlert"));

#line default
#line hidden
            EndContext();
            BeginContext(420, 129, true);
            WriteLiteral("\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-md-5 mx-auto\">\r\n            <div class=\"login-form form \">\r\n\r\n                ");
            EndContext();
            BeginContext(550, 40, false);
#line 23 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
           Write(await Component.InvokeAsync("FormTitle"));

#line default
#line hidden
            EndContext();
            BeginContext(590, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 25 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
                 using (Html.BeginForm("Login", "Login", FormMethod.Post, new { Area = "System", id = "login" }))
                {
                    

#line default
#line hidden
            BeginContext(749, 32, false);
#line 27 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
               Write(Html.HiddenFor(e => e.ReturnUrl));

#line default
#line hidden
            EndContext();
            BeginContext(804, 32, false);
#line 28 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
               Write(Html.HiddenFor(e => e.SubDomain));

#line default
#line hidden
            EndContext();
#line 28 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
                                                     
                    using (Html.DevExtreme().ValidationGroup())
                    {

#line default
#line hidden
            BeginContext(926, 162, true);
            WriteLiteral("                        <div class=\"form-group\">\r\n                            <div class=\"dx-field\">\r\n                                <div class=\"dx-field-label\">");
            EndContext();
            BeginContext(1089, 24, false);
#line 33 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
                                                       Write(Resources.Login_UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1113, 106, true);
            WriteLiteral("</div>\r\n                                <div class=\"dx-field-value\">\r\n                                    ");
            EndContext();
            BeginContext(1221, 524, false);
#line 35 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
                                Write(Html.DevExtreme().TextBox()
                                                                                        .Placeholder(Resources.Login_UserName)
                                                                                        .ShowClearButton(true)
                                                                                        .Name("UserName")
                                                                                        .Value(Model.UserName)
                                    );

#line default
#line hidden
            EndContext();
            BeginContext(1746, 110, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
            BeginContext(1858, 162, true);
            WriteLiteral("                        <div class=\"form-group\">\r\n                            <div class=\"dx-field\">\r\n                                <div class=\"dx-field-label\">");
            EndContext();
            BeginContext(2021, 24, false);
#line 47 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
                                                       Write(Resources.Login_Password);

#line default
#line hidden
            EndContext();
            BeginContext(2045, 106, true);
            WriteLiteral("</div>\r\n                                <div class=\"dx-field-value\">\r\n                                    ");
            EndContext();
            BeginContext(2153, 626, false);
#line 49 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
                                Write(Html.DevExtreme().TextBox()
                                                                                     .Placeholder(Resources.Login_Password)
                                                                                     .ShowClearButton(true)
                                                                                     .Name("Password")
                                                                                     .Mode(TextBoxMode.Password)
                                                                                     .Value(Model.Password)
                                    );

#line default
#line hidden
            EndContext();
            BeginContext(2780, 110, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
            BeginContext(2892, 89, true);
            WriteLiteral("                        <div class=\"col-md-12 text-right \">\r\n                            ");
            EndContext();
            BeginContext(2983, 493, false);
#line 61 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
                        Write(Html.DevExtreme().Button()
                                                                                     .ID("logIn")
                                                                                     .Text(Resources.Login_Submit)
                                                                                     .Type(ButtonType.Normal)
                                                                                     .UseSubmitBehavior(true)
                            );

#line default
#line hidden
            EndContext();
            BeginContext(3477, 34, true);
            WriteLiteral("\r\n                        </div>\r\n");
            EndContext();
#line 68 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Login\Index.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(3553, 54, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LoginDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
