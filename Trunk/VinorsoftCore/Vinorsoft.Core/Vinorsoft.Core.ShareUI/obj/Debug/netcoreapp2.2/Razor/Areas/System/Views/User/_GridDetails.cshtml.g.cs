#pragma checksum "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\_GridDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4abbd7eaa0f1985709beb5058db178558a50c8f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_System_Views_User__GridDetails), @"mvc.1.0.view", @"/Areas/System/Views/User/_GridDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/System/Views/User/_GridDetails.cshtml", typeof(AspNetCore.Areas_System_Views_User__GridDetails))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4abbd7eaa0f1985709beb5058db178558a50c8f3", @"/Areas/System/Views/User/_GridDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e89d903c5125a6a79e61c03c342c851b58031aab", @"/Areas/System/Views/_ViewImports.cshtml")]
    public class Areas_System_Views_User__GridDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(2, 814, false);
#line 1 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\_GridDetails.cshtml"
Write(Html.DevExtreme().Form<UserDTO>
        ().ColCount(3).Items(items =>
        {
            items.AddGroup().Caption(Resources.User_Info).Items(groupItems =>
            {
                groupItems.AddSimpleFor(m => m.Email).Editor(e => e.TextBox().Mode(TextBoxMode.Email).ReadOnly(true));
                groupItems.AddSimpleFor(m => m.Phone).Editor(e => e.TextBox().Mask("+84 X00 000 000").MaskRules(new { X = new JS("/[02-9]/") }).ReadOnly(true));
                groupItems.AddSimpleFor(m => m.DisplayUserGroupIds).Editor(e => e.TagBox().Disabled(true).DataSource(d => d.Mvc().LoadAction("GetUserGroup")).Placeholder(Resources.Dropdown_Placeholder).DisplayExpr("Name").ValueExpr("Id")).ColSpan(2);
            }).ColSpan(3).ColCount(3);

        }).ValidationGroup("User").FormData(new JS("data"))
);

#line default
#line hidden
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
