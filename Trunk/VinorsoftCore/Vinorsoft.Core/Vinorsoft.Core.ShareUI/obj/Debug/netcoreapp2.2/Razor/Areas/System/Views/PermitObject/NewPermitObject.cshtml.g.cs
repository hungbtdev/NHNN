#pragma checksum "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0cac12a32b4159e650333388b79f7f938d69c7db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_System_Views_PermitObject_NewPermitObject), @"mvc.1.0.view", @"/Areas/System/Views/PermitObject/NewPermitObject.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/System/Views/PermitObject/NewPermitObject.cshtml", typeof(AspNetCore.Areas_System_Views_PermitObject_NewPermitObject))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cac12a32b4159e650333388b79f7f938d69c7db", @"/Areas/System/Views/PermitObject/NewPermitObject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e89d903c5125a6a79e61c03c342c851b58031aab", @"/Areas/System/Views/_ViewImports.cshtml")]
    public class Areas_System_Views_PermitObject_NewPermitObject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PermitObjectDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
  
    var controllerName = ViewContext.RouteData.Values["controller"].ToString();
    var areaName = ViewContext.RouteData.Values["area"].ToString();

#line default
#line hidden
            BeginContext(181, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(184, 40, false);
#line 7 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
Write(await Component.InvokeAsync("FormTitle"));

#line default
#line hidden
            EndContext();
            BeginContext(224, 35, true);
            WriteLiteral("\r\n\r\n<div id=\"form-container\">\r\n    ");
            EndContext();
            BeginContext(260, 38, false);
#line 10 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
Write(await Html.PartialAsync("_ErrorAlert"));

#line default
#line hidden
            EndContext();
            BeginContext(298, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 12 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
     using (Html.BeginForm("NewPermitObject", controllerName, FormMethod.Post, new { Area = areaName, id = "UpdatePermitObjectForm" }))
    {

        

#line default
#line hidden
            BeginContext(457, 25, false);
#line 15 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
   Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
            EndContext();
            BeginContext(493, 30, false);
#line 16 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
   Write(Html.HiddenFor(m => m.Created));

#line default
#line hidden
            EndContext();
            BeginContext(534, 32, false);
#line 17 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
   Write(Html.HiddenFor(m => m.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(580, 2276, false);
#line 19 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
    Write(Html.DevExtreme().Form<PermitObjectDTO>().ID("form").ColCount(4).Items(items =>
                                                        {
                                                            items.AddGroup().Caption(Resources.PermitObject_Info).Items(groupItems =>
                                                            {
                                                                groupItems.AddSimpleFor(m => m.Code).IsRequired(true);
                                                                groupItems.AddSimpleFor(m => m.Name).IsRequired(true);
                                                                groupItems.AddSimpleFor(m => m.Description)
                                                                .Editor(e => e.TextArea().Height(80)).ColSpan(2);
                                                            }).ColSpan(4).ColCount(4);

                                                            items.AddGroup().Caption(Resources.Controller_List).Items(groupItems =>
                                                            {
                                                                groupItems.AddSimpleFor(m => m.ControllerList).Editor(e => e.TagBox().DataSource(d => d.Mvc().LoadAction("GetControllers").Key("Id")).DisplayExpr("Name").ValueExpr("Id").SearchEnabled(true).ShowSelectionControls(true).HideSelectedItems(true).ShowClearButton(true).Placeholder(Resources.Dropdown_Placeholder)).ColSpan(4);
                                                            }).ColSpan(4);

                                                            items.AddGroup().Caption(Resources.Sidebar_List).Items(groupItems =>
                                               {
                                                   groupItems.AddSimpleFor(m => m.SelectedSidebars).Editor(e => e.TagBox().DataSource(d => d.Mvc().LoadAction("GetSideBars").Key("Id")).DisplayExpr("Name").ValueExpr("Id").SearchEnabled(true).ShowSelectionControls(true).HideSelectedItems(true).ShowClearButton(true).Placeholder(Resources.Dropdown_Placeholder)).ColSpan(4);
                                               }).ColSpan(4);

                                                        }).ValidationGroup("PermitObject").FormData(Model) );

#line default
#line hidden
            EndContext();
            BeginContext(2859, 16, true);
            WriteLiteral("        <hr />\r\n");
            EndContext();
            BeginContext(2877, 91, true);
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-md-12 text-right\">\r\n                ");
            EndContext();
            BeginContext(2970, 134, false);
#line 44 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
            Write(Html.DevExtreme().Button().Text(Resources.PermitObject_Cancel).UseSubmitBehavior(false).Width(100).OnClick("goBack")
                );

#line default
#line hidden
            EndContext();
            BeginContext(3105, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(3125, 172, false);
#line 46 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
            Write(Html.DevExtreme().Button().Text(Resources.PermitObject_Submit).Type(ButtonType.Success).UseSubmitBehavior(true).ValidationGroup("PermitObject").Width(100)
                );

#line default
#line hidden
            EndContext();
            BeginContext(3298, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 50 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
    }

#line default
#line hidden
            BeginContext(3343, 77, true);
            WriteLiteral("</div>\r\n\r\n<script>\r\n    function goBack() {\r\n        window.location.href = \'");
            EndContext();
            BeginContext(3421, 60, false);
#line 55 "E:\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\NewPermitObject.cshtml"
                           Write(Url.Action("Index", controllerName, new { Area = areaName }));

#line default
#line hidden
            EndContext();
            BeginContext(3481, 19, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PermitObjectDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591