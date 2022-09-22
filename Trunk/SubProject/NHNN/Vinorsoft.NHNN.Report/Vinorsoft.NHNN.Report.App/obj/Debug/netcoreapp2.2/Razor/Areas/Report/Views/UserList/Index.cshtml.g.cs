#pragma checksum "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\UserList\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "300425dd826a5ddc45d87ef0d7e7415b0c6b0bb1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Report_Views_UserList_Index), @"mvc.1.0.view", @"/Areas/Report/Views/UserList/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Report/Views/UserList/Index.cshtml", typeof(AspNetCore.Areas_Report_Views_UserList_Index))]
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
#line 2 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#line 3 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\_ViewImports.cshtml"
using Vinorsoft.Core.DTO;

#line default
#line hidden
#line 4 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\_ViewImports.cshtml"
using Vinorsoft.Core.App;

#line default
#line hidden
#line 5 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\_ViewImports.cshtml"
using Vinorsoft.Core.App.Context;

#line default
#line hidden
#line 6 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\_ViewImports.cshtml"
using Vinorsoft.Core.App.Extensions;

#line default
#line hidden
#line 7 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\_ViewImports.cshtml"
using Vinorsoft.NHNN.Report.DTO;

#line default
#line hidden
#line 8 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\_ViewImports.cshtml"
using Vinorsoft.NHNN.Report.App;

#line default
#line hidden
#line 9 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\_ViewImports.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"300425dd826a5ddc45d87ef0d7e7415b0c6b0bb1", @"/Areas/Report/Views/UserList/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad1064e44f051aa521ac025f0006b1a14e100247", @"/Areas/Report/Views/_ViewImports.cshtml")]
    public class Areas_Report_Views_UserList_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\UserList\Index.cshtml"
  
    var controllerName = ViewContext.RouteData.Values["controller"].ToString();
    var areaName = ViewContext.RouteData.Values["area"].ToString();

#line default
#line hidden
            BeginContext(157, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(160, 40, false);
#line 6 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\UserList\Index.cshtml"
Write(await Component.InvokeAsync("FormTitle"));

#line default
#line hidden
            EndContext();
            BeginContext(200, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(206, 1845, false);
#line 8 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\UserList\Index.cshtml"
Write(Html.DevExtreme().DataGrid<UserViewListDTO>
        ().ID("gridContainer").DataSource(d => d.Mvc().Controller(controllerName).Area(areaName).LoadAction("Get").DeleteAction("Delete").Key("EmployeeNumber")).WordWrapEnabled(true)
        .Columns(column =>
        {
            column.AddFor(m => m.EmployeeNumber).Alignment(HorizontalAlignment.Center).Width(100);
            column.AddFor(m => m.FullName);
            column.AddFor(m => m.ParentDeptName);
            column.AddFor(m => m.DeptName);
            column.AddFor(m => m.JobtitleName);
            column.AddFor(m => m.IsNoCaculate).Width(100).TrueText("X").FalseText(" ");
            column.Add().Type(GridCommandColumnType.Buttons).Buttons(b =>
            {
                b.Add().Icon("fa fa-angle-double-right").OnClick("viewAccessHistory").Hint(Vinorsoft_NHNN_Report_DevEx_App_Resource.Button_Detail);

                b.Add().Icon("fa fa-cogs").OnClick("latesoonConfig").Hint(Vinorsoft_NHNN_Report_DevEx_App_Resource.Button_Config_Latesoon);

            }).Width(100);
        }).ToDefaultOption().Grouping(grouping => grouping.AutoExpandAll(false))
         .SortByGroupSummaryInfo(i => i.Add().SummaryItem("count"))
        .Summary(s => s.TotalItems(items =>
        {
            items.AddFor(m => m.EmployeeNumber).SummaryType(SummaryType.Count).DisplayFormat(Vinorsoft_NHNN_Report_DevEx_App_Resource.Sumary_Total + " {0}");
        }).GroupItems(items =>
        {
            items.Add()
               .SummaryType(SummaryType.Count)
               .DisplayFormat("{0}");
        })).Export(e => e.Enabled(true).AllowExportSelectedData(true).FileName($"{Vinorsoft_NHNN_Report_DevEx_App_Resource.Export_UserList_FileName}__Tháng {DateTime.Now.ToString("MM-yyyy")}")).OnFileSaving("OnFileSaving").OnToolbarPreparing("OnToolbarPreparing")
);

#line default
#line hidden
            EndContext();
            BeginContext(2052, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(2057, 47, false);
#line 38 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\UserList\Index.cshtml"
Write(await Html.PartialAsync("_ProcessExcelScripts"));

#line default
#line hidden
            EndContext();
            BeginContext(2104, 85, true);
            WriteLiteral("\r\n\r\n<script>\r\n     function latesoonConfig(e) {\r\n            window.location.href = \'");
            EndContext();
            BeginContext(2190, 61, false);
#line 42 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\UserList\Index.cshtml"
                               Write(Url.Action("Config", controllerName, new { Area = areaName }));

#line default
#line hidden
            EndContext();
            BeginContext(2251, 116, true);
            WriteLiteral("/\' + e.row.data.EmployeeNumber;\r\n     }\r\n\r\n    function viewAccessHistory(e) {\r\n            window.location.href = \'");
            EndContext();
            BeginContext(2368, 72, false);
#line 46 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\UserList\Index.cshtml"
                               Write(Url.Action("CheckInOutHistory", controllerName, new { Area = areaName }));

#line default
#line hidden
            EndContext();
            BeginContext(2440, 57, true);
            WriteLiteral("/\' + e.row.data.EmployeeNumber;\r\n        }\r\n</script>\r\n\r\n");
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
