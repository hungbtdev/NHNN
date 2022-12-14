#pragma checksum "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5205b51881f75ef3496c4029a256d567636415b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_System_Views_PermitObject_Index), @"mvc.1.0.view", @"/Areas/System/Views/PermitObject/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/System/Views/PermitObject/Index.cshtml", typeof(AspNetCore.Areas_System_Views_PermitObject_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5205b51881f75ef3496c4029a256d567636415b0", @"/Areas/System/Views/PermitObject/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e89d903c5125a6a79e61c03c342c851b58031aab", @"/Areas/System/Views/_ViewImports.cshtml")]
    public class Areas_System_Views_PermitObject_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\Index.cshtml"
  
    var controllerName = ViewContext.RouteData.Values["controller"].ToString();
    var areaName = ViewContext.RouteData.Values["area"].ToString();

#line default
#line hidden
            BeginContext(157, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(160, 40, false);
#line 6 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\Index.cshtml"
Write(await Component.InvokeAsync("FormTitle"));

#line default
#line hidden
            EndContext();
            BeginContext(200, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(206, 1361, false);
#line 8 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\Index.cshtml"
Write(Html.DevExtreme().DataGrid<PermitObjectDTO>().ToCatalogueDefaultOption().DataSource(d => d.Mvc()
                                                                            .Controller(controllerName)
                                                                            .Area(areaName)
                                                                            .LoadAction("Get")
                                                                            .DeleteAction("Delete")
                                                                            .Key("Id"))
                                                                       .OnEditingStart("onUpdateItem")
                                                                       .OnToolbarPreparing("toolbar_preparing")
                                                                       .MasterDetail(detail =>
                                                                       {
                                                                           detail.Enabled(true);
                                                                           detail.Template(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(1371, 1, true);
    WriteLiteral(" ");
    EndContext();
    BeginContext(1373, 46, false);
#line 19 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\Index.cshtml"
                                                                                              Write(await Html.PartialAsync("_PermitObjectDetail"));

#line default
#line hidden
    EndContext();
    BeginContext(1419, 1, true);
    WriteLiteral(" ");
    EndContext();
    PopWriter();
}
));
                                                                                                                                                   })
);

#line default
#line hidden
            EndContext();
            BeginContext(1583, 106, true);
            WriteLiteral("\r\n\r\n<script>\r\n\r\n    function onUpdateItem(e) {\r\n        e.cancel = true;\r\n        window.location.href = \'");
            EndContext();
            BeginContext(1690, 73, false);
#line 27 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\Index.cshtml"
                           Write(Url.Action("UpdatePermitObject", controllerName, new { Area = areaName }));

#line default
#line hidden
            EndContext();
            BeginContext(1763, 342, true);
            WriteLiteral(@"/' + e.key;
    }

    function toolbar_preparing(e) {
        var dataGrid = e.component;
        e.toolbarOptions.items.unshift({
            location: ""after"",
            widget: ""dxButton"",
            options: {
                icon: ""plus"",
                onClick: function () {
                    window.location.href = '");
            EndContext();
            BeginContext(2106, 71, false);
#line 38 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\PermitObject\Index.cshtml"
                                       Write(Url.Action("NewPermitObject", controllerName , new { Area = areaName }));

#line default
#line hidden
            EndContext();
            BeginContext(2177, 69, true);
            WriteLiteral("\'\r\n                }\r\n            }\r\n        })\r\n    }\r\n</script>\r\n\r\n");
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
