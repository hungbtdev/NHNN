#pragma checksum "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\UserProfile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4acc32433bc5aae83978a8a8098a6d51790190de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_System_Views_UserProfile_Index), @"mvc.1.0.view", @"/Areas/System/Views/UserProfile/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/System/Views/UserProfile/Index.cshtml", typeof(AspNetCore.Areas_System_Views_UserProfile_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4acc32433bc5aae83978a8a8098a6d51790190de", @"/Areas/System/Views/UserProfile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e89d903c5125a6a79e61c03c342c851b58031aab", @"/Areas/System/Views/_ViewImports.cshtml")]
    public class Areas_System_Views_UserProfile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserProfileDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\UserProfile\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(58, 40, false);
#line 6 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\UserProfile\Index.cshtml"
Write(await Component.InvokeAsync("FormTitle"));

#line default
#line hidden
            EndContext();
            BeginContext(98, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 8 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\UserProfile\Index.cshtml"
 using (Html.BeginForm("UpdateProfile", "UserProfile", FormMethod.Post, new { Area = "System", id = "form-change-password" }))
{
    

#line default
#line hidden
            BeginContext(238, 25, false);
#line 10 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\UserProfile\Index.cshtml"
Write(Html.HiddenFor(e => e.Id));

#line default
#line hidden
            EndContext();
            BeginContext(273, 1181, false);
#line 12 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\UserProfile\Index.cshtml"
Write(Html.DevExtreme().Form<UserProfileDTO>()
                        .ID("form-update-profile")
                        .ColCount(3)
                        .Items(items =>
                        {
                            items.AddEmpty();
                            items.AddGroup()
                    .Items(groupItems =>
                    {
                                groupItems.AddSimpleFor(m => m.FirstName);

                                groupItems.AddSimpleFor(m => m.LastName);

                                groupItems.AddSimpleFor(m => m.Email)
                        .Editor(e => e.TextBox().Mode(TextBoxMode.Email));

                                groupItems.AddSimpleFor(m => m.Phone)
                      .Editor(e => e.TextBox().Mode(TextBoxMode.Tel));

                                groupItems.AddSimple()
                        .Template(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(1178, 38, false);
#line 32 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\UserProfile\Index.cshtml"
                                    Write(await Html.PartialAsync("_FormFooter"));

#line default
#line hidden
    EndContext();
    PopWriter();
}
));

                                                        });
                                                        items.AddEmpty();
                                                    }).ValidationGroup("update-profile").FormData(Model));

#line default
#line hidden
            EndContext();
#line 36 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\UserProfile\Index.cshtml"
                                                                                                         
}

#line default
#line hidden
            BeginContext(1475, 93, true);
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n     function goBack() {\r\n        window.location.href = \'");
            EndContext();
            BeginContext(1569, 46, false);
#line 41 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\UserProfile\Index.cshtml"
                           Write(Url.Action("Index", "Home", new { Area = "" }));

#line default
#line hidden
            EndContext();
            BeginContext(1615, 19, true);
            WriteLiteral("\'\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserProfileDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
