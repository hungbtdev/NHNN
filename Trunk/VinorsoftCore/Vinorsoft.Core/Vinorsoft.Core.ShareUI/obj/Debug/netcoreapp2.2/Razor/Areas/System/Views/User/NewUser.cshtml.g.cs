#pragma checksum "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e78a9ef16434d7dcadc4b38961cf794c5818e785"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_System_Views_User_NewUser), @"mvc.1.0.view", @"/Areas/System/Views/User/NewUser.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/System/Views/User/NewUser.cshtml", typeof(AspNetCore.Areas_System_Views_User_NewUser))]
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
#line 2 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#line 3 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using Vinorsoft.Core.DTO;

#line default
#line hidden
#line 4 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using Vinorsoft.Core.Resx;

#line default
#line hidden
#line 5 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using Vinorsoft.Core.Domain;

#line default
#line hidden
#line 6 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using Vinorsoft.Core.App;

#line default
#line hidden
#line 7 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\_ViewImports.cshtml"
using Vinorsoft.Core.App.Context;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e78a9ef16434d7dcadc4b38961cf794c5818e785", @"/Areas/System/Views/User/NewUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e89d903c5125a6a79e61c03c342c851b58031aab", @"/Areas/System/Views/_ViewImports.cshtml")]
    public class Areas_System_Views_User_NewUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NewUserDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
  
    var controllerName = ViewContext.RouteData.Values["controller"].ToString();
    var areaName = ViewContext.RouteData.Values["area"].ToString();

#line default
#line hidden
            BeginContext(176, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(179, 40, false);
#line 7 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
Write(await Component.InvokeAsync("FormTitle"));

#line default
#line hidden
            EndContext();
            BeginContext(219, 37, true);
            WriteLiteral("\r\n\r\n<div id=\"form-container\">\r\n\r\n    ");
            EndContext();
            BeginContext(257, 38, false);
#line 11 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
Write(await Html.PartialAsync("_ErrorAlert"));

#line default
#line hidden
            EndContext();
            BeginContext(295, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 13 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
     using (Html.BeginForm("NewUser", controllerName, FormMethod.Post, new { Area = areaName, id = "NewUserForm" }))
    {
        

#line default
#line hidden
            BeginContext(433, 25, false);
#line 15 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
   Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
            EndContext();
            BeginContext(469, 30, false);
#line 16 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
   Write(Html.HiddenFor(m => m.Created));

#line default
#line hidden
            EndContext();
            BeginContext(510, 32, false);
#line 17 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
   Write(Html.HiddenFor(m => m.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(553, 30, false);
#line 18 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
   Write(Html.HiddenFor(m => m.Updated));

#line default
#line hidden
            EndContext();
            BeginContext(594, 32, false);
#line 19 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
   Write(Html.HiddenFor(m => m.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(640, 1798, false);
#line 21 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
    Write(Html.DevExtreme().Form<NewUserDTO>
            ().ID("form").ColCount(3).Items(items =>
            {
                items.AddGroup().Caption(Resources.Account_Info).Items(groupItems =>
                {
                    groupItems.AddSimpleFor(m => m.Username);
                    groupItems.AddSimpleFor(m => m.Password).Editor(e => e.TextBox().Mode(TextBoxMode.Password));
                    groupItems.AddSimpleFor(m => m.ConfirmPassword).Editor(e => e.TextBox().Mode(TextBoxMode.Password));
                }).ColSpan(1).ColCount(1);

                items.AddGroup().Caption(Resources.User_Info).Items(groupItems =>
                {
                    groupItems.AddSimpleFor(m => m.FirstName);
                    groupItems.AddSimpleFor(m => m.LastName);
                    groupItems.AddSimpleFor(m => m.Email).Editor(e => e.TextBox().Mode(TextBoxMode.Email));
                    groupItems.AddSimpleFor(m => m.Phone).Editor(e => e.TextBox().Mask("+84 X00 000 000").MaskRules(new { X = new JS("/[02-9]/") }));
                    groupItems.AddSimpleFor(m => m.Locked);
                    groupItems.AddSimpleFor(m => m.LockedEnd);
                    groupItems.AddSimpleFor(m => m.FailedCount).Editor(e => e.NumberBox().Max(5));
                    groupItems.AddSimpleFor(m => m.StatusId).Editor(e => e.Lookup().Placeholder(Resources.Dropdown_Placeholder).DataSource(d => d.Mvc().LoadAction("GetUserStatus")));
                    groupItems.AddSimpleFor(m => m.UserGroupIds).Editor(e => e.TagBox().DataSource(d => d.Mvc().LoadAction("GetUserGroup")).Placeholder(Resources.Dropdown_Placeholder).DisplayExpr("Name").ValueExpr("Id")).ColSpan(2);
                }).ColSpan(2).ColCount(2);

            }).ValidationGroup("User").FormData(Model)
        );

#line default
#line hidden
            EndContext();
            BeginContext(2441, 16, true);
            WriteLiteral("        <hr />\r\n");
            EndContext();
            BeginContext(2459, 91, true);
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-md-12 text-right\">\r\n                ");
            EndContext();
            BeginContext(2552, 128, false);
#line 50 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
            Write(Html.DevExtreme().Button().Text(Resources.Button_Cancel).UseSubmitBehavior(false).Width(100).OnClick("goBack")
                );

#line default
#line hidden
            EndContext();
            BeginContext(2681, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2701, 156, false);
#line 52 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
            Write(Html.DevExtreme().Button().Text(Resources.Button_Save).Type(ButtonType.Success).UseSubmitBehavior(true).ValidationGroup("User").Width(100)
                );

#line default
#line hidden
            EndContext();
            BeginContext(2858, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 56 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
    }

#line default
#line hidden
            BeginContext(2903, 77, true);
            WriteLiteral("</div>\r\n\r\n<script>\r\n    function goBack() {\r\n        window.location.href = \'");
            EndContext();
            BeginContext(2981, 60, false);
#line 61 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\User\NewUser.cshtml"
                           Write(Url.Action("Index", controllerName, new { Area = areaName }));

#line default
#line hidden
            EndContext();
            BeginContext(3041, 19, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NewUserDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
