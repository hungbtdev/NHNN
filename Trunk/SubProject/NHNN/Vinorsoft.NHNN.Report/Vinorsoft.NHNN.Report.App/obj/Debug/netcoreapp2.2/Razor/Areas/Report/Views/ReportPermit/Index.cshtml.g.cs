#pragma checksum "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportPermit\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52414f0ffecc86f4b505bed686b851537c6a3c55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Report_Views_ReportPermit_Index), @"mvc.1.0.view", @"/Areas/Report/Views/ReportPermit/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Report/Views/ReportPermit/Index.cshtml", typeof(AspNetCore.Areas_Report_Views_ReportPermit_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52414f0ffecc86f4b505bed686b851537c6a3c55", @"/Areas/Report/Views/ReportPermit/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad1064e44f051aa521ac025f0006b1a14e100247", @"/Areas/Report/Views/_ViewImports.cshtml")]
    public class Areas_Report_Views_ReportPermit_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SearchReportCarDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(30, 40, false);
#line 3 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportPermit\Index.cshtml"
Write(await Component.InvokeAsync("FormTitle"));

#line default
#line hidden
            EndContext();
            BeginContext(70, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(76, 1465, false);
#line 5 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportPermit\Index.cshtml"
Write(Html.DevExtreme().DataGrid<UserPermitConfigDTO>().ID("gridContainer").DataSource(d => d.Mvc().LoadAction("Get").InsertAction("Insert").DeleteAction("Delete").UpdateAction("Update").Key("Id"))
    .KeyExpr("Id")
    .ShowBorders(true)
    .ShowColumnLines(true)
    .ShowRowLines(true)
                .WordWrapEnabled(true)
                .Columns(column =>
                {

                    column.AddFor(m => m.UserId).Width(200).Alignment(HorizontalAlignment.Center).Lookup(e => e.DataSource(d => d.Mvc().LoadAction("GetUsers").Key("Id")).DisplayExpr("Name").ValueExpr("Id").AllowClearing(true)).FormItem(f=>f.ColSpan(2));
                    column.AddFor(m => m.DeptName).MinWidth(200).FormItem(f => f.ColSpan(2).Editor(e=>e.TextArea().Height(100)));
                    column.AddFor(m => m.Created).Width(100).Format(Contants.DateFormat).FormItem(f => f.ColSpan(2).CssClass("d-none"));

                }).OnInitNewRow("permitConfig.OnInitNewRow")
                .Editing(e => e.AllowAdding(true).AllowDeleting(true).AllowUpdating(true).UseIcons(true).Mode(GridEditMode.Popup).Popup(p => p
           .ShowTitle(false)
           .ShowCloseButton(true)
           .MaxWidth(500)
           .Height(320)
           .Position(pos => pos
               .My(HorizontalAlignment.Center, VerticalAlignment.Top)
               .At(HorizontalAlignment.Center, VerticalAlignment.Top)
               .Of(new JS("window"))
           )))
);

#line default
#line hidden
            EndContext();
            BeginContext(1542, 196, true);
            WriteLiteral("\r\n\r\n<script>\r\n    var permitConfig = {\r\n        OnInitNewRow: function (e) {\r\n            e.data[\"Id\"] = uuidv4();\r\n            e.data[\"Created\"] = new Date();\r\n            e.data[\"CreatedBy\"] = \'");
            EndContext();
            BeginContext(1739, 42, false);
#line 36 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportPermit\Index.cshtml"
                              Write(LoginContext.Instance.CurrentUser.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1781, 37, true);
            WriteLiteral("\';\r\n        }\r\n    }\r\n\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SearchReportCarDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
