#pragma checksum "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportOverTime\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7370bea234b4c8ab83b069e093171d2781fb82ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Report_Views_ReportOverTime_Index), @"mvc.1.0.view", @"/Areas/Report/Views/ReportOverTime/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Report/Views/ReportOverTime/Index.cshtml", typeof(AspNetCore.Areas_Report_Views_ReportOverTime_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7370bea234b4c8ab83b069e093171d2781fb82ea", @"/Areas/Report/Views/ReportOverTime/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad1064e44f051aa521ac025f0006b1a14e100247", @"/Areas/Report/Views/_ViewImports.cshtml")]
    public class Areas_Report_Views_ReportOverTime_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SearchReportOverTimeDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportOverTime\Index.cshtml"
  
    var controllerName = ViewContext.RouteData.Values["controller"].ToString();
    var areaName = ViewContext.RouteData.Values["area"].ToString();

#line default
#line hidden
            BeginContext(189, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(192, 40, false);
#line 7 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportOverTime\Index.cshtml"
Write(await Component.InvokeAsync("FormTitle"));

#line default
#line hidden
            EndContext();
            BeginContext(232, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportOverTime\Index.cshtml"
 using (Html.BeginForm("Index", controllerName, FormMethod.Get, new { Area = areaName, id = "SearchForm" }))
{
    

#line default
#line hidden
            BeginContext(353, 1974, false);
#line 10 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportOverTime\Index.cshtml"
Write(Html.DevExtreme().Form<SearchReportOverTimeDTO>
                                                                                    ().ID("form").ColCount(3).Items(items =>
                                                                                    {
                                                                                        items.AddEmpty();
                                                                                        items.AddGroup().ColCount(3).Items(groupItems =>
                                                                        {
                                                                            groupItems.AddSimpleFor(m => m.Month).Editor(e => e.NumberBox().Max(12).Width(100));
                                                                            groupItems.AddSimpleFor(m => m.Year).Editor(e => e.NumberBox().Max(9999).Width(100));
                                                                            groupItems.AddSimple().Template(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(1375, 2, true);
    WriteLiteral("\r\n");
    EndContext();
    BeginContext(1377, 353, false);
#line 19 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportOverTime\Index.cshtml"
Write(Html.DevExtreme().Button().Icon("fa fa-search").Text(Vinorsoft_NHNN_Report_DevEx_App_Resource.Button_Submit).Type(ButtonType.Normal).UseSubmitBehavior(true).ValidationGroup("User").Width(100)
                                                                                );

#line default
#line hidden
    EndContext();
    BeginContext(1733, 78, true);
    WriteLiteral("\r\n                                                                            ");
    EndContext();
    PopWriter();
}
));
                                                                                                                                            });
                                                                                                                                                            items.AddEmpty();

                                                                                                                                                        }).ValidationGroup("User").FormData(Model)
    );

#line default
#line hidden
            EndContext();
#line 26 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportOverTime\Index.cshtml"
     
}

#line default
#line hidden
            BeginContext(2350, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2354, 22015, false);
#line 29 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportOverTime\Index.cshtml"
Write(Html.DevExtreme().DataGrid<Vinorsoft.NHNN.Report.DTO.ReportDTO.OverTimeRowDTO>
                                                ().ID("gridContainer").DataSource(d => d.Mvc().Controller(controllerName).Area(areaName).LoadAction("Get").LoadParams(new { month = Model.Month, year = Model.Year }).Key("EmployeeNumber"))
                                                .WordWrapEnabled(true)
                                                .Columns(column =>
                                                {

                                                    column.AddFor(m => m.EmployeeNumber).Width(80).Alignment(HorizontalAlignment.Center).Fixed(true);
                                                    column.AddFor(m => m.FullName).Width(150).Fixed(true);
                                                    column.AddFor(m => m.ParentDeptName).Width(150).AllowHeaderFiltering(true).AllowFiltering(false);
                                                    column.AddFor(m => m.DeptName).Width(150).AllowHeaderFiltering(true).AllowFiltering(false);
                                                    column.AddFor(m => m.JobtitleName).Width(150).AllowHeaderFiltering(true).AllowFiltering(false);
                                                    column.Add().CssClass(Model.GetHighLightCss(0)).Caption("1").Columns(a =>
                                                    {
                                                        a.AddFor(m => m._1.Summary).CssClass(Model.GetHighLightCss(0)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(0)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("2").CssClass(Model.GetHighLightCss(1)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._2.Summary).CssClass(Model.GetHighLightCss(1)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(1)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("3").CssClass(Model.GetHighLightCss(2)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._3.Summary).CssClass(Model.GetHighLightCss(2)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(2)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("4").CssClass(Model.GetHighLightCss(3)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._4.Summary).CssClass(Model.GetHighLightCss(3)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(3)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("5").CssClass(Model.GetHighLightCss(4)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._5.Summary).CssClass(Model.GetHighLightCss(4)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(4)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("6").CssClass(Model.GetHighLightCss(5)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._6.Summary).CssClass(Model.GetHighLightCss(5)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(5)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("7").CssClass(Model.GetHighLightCss(6)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._7.Summary).CssClass(Model.GetHighLightCss(6)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(6)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("8").CssClass(Model.GetHighLightCss(7)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._8.Summary).CssClass(Model.GetHighLightCss(7)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(7)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("9").CssClass(Model.GetHighLightCss(8)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._9.Summary).CssClass(Model.GetHighLightCss(8)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(8)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("10").CssClass(Model.GetHighLightCss(9)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._10.Summary).CssClass(Model.GetHighLightCss(9)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(9)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("11").CssClass(Model.GetHighLightCss(10)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._11.Summary).CssClass(Model.GetHighLightCss(10)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(10)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("12").CssClass(Model.GetHighLightCss(11)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._12.Summary).CssClass(Model.GetHighLightCss(11)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(11)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("13").CssClass(Model.GetHighLightCss(12)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._13.Summary).CssClass(Model.GetHighLightCss(12)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(12)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("14").CssClass(Model.GetHighLightCss(13)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._14.Summary).CssClass(Model.GetHighLightCss(13)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(13)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);


                                                    column.Add().Caption("15").CssClass(Model.GetHighLightCss(14)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._15.Summary).CssClass(Model.GetHighLightCss(14)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(14)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);


                                                    column.Add().Caption("16").CssClass(Model.GetHighLightCss(15)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._16.Summary).CssClass(Model.GetHighLightCss(15)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(15)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);


                                                    column.Add().Caption("17").CssClass(Model.GetHighLightCss(16)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._17.Summary).CssClass(Model.GetHighLightCss(16)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(16)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);


                                                    column.Add().Caption("18").CssClass(Model.GetHighLightCss(17)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._18.Summary).CssClass(Model.GetHighLightCss(17)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(17)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("19").CssClass(Model.GetHighLightCss(18)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._19.Summary).CssClass(Model.GetHighLightCss(18)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(18)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("20").CssClass(Model.GetHighLightCss(19)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._20.Summary).CssClass(Model.GetHighLightCss(19)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(19)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("21").CssClass(Model.GetHighLightCss(20)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._21.Summary).CssClass(Model.GetHighLightCss(20)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(20)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("22").CssClass(Model.GetHighLightCss(21)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._22.Summary).CssClass(Model.GetHighLightCss(21)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(21)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("23").CssClass(Model.GetHighLightCss(22)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._23.Summary).CssClass(Model.GetHighLightCss(22)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(22)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("24").CssClass(Model.GetHighLightCss(23)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._24.Summary).CssClass(Model.GetHighLightCss(23)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(23)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("25").CssClass(Model.GetHighLightCss(24)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._25.Summary).CssClass(Model.GetHighLightCss(24)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(24)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("26").CssClass(Model.GetHighLightCss(25)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._26.Summary).CssClass(Model.GetHighLightCss(25)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(25)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("27").CssClass(Model.GetHighLightCss(26)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._27.Summary).CssClass(Model.GetHighLightCss(26)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(26)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    column.Add().Caption("28").CssClass(Model.GetHighLightCss(27)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._28.Summary).CssClass(Model.GetHighLightCss(27)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(27)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).Visible(Model.Show_28).AllowSorting(false);

                                                    column.Add().Caption("29").CssClass(Model.GetHighLightCss(28)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._29.Summary).CssClass(Model.GetHighLightCss(28)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(28)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).Visible(Model.Show_29).AllowSorting(false);

                                                    column.Add().Caption("30").CssClass(Model.GetHighLightCss(29)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._30.Summary).CssClass(Model.GetHighLightCss(29)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(29)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).Visible(Model.Show_30).AllowSorting(false);

                                                    column.Add().Caption("31").CssClass(Model.GetHighLightCss(31)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m._31.Summary).CssClass(Model.GetHighLightCss(31)).Width(90).Alignment(HorizontalAlignment.Center).Caption(Model.GetDayOfWeek(30)).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).Visible(Model.Show_31).AllowSorting(false);

                                                    column.Add().Caption("(Giờ:Phút)").CssClass(Model.GetHighLightCss(31)).Columns(a =>
                                                    {
                                                        a.AddFor(m => m.WD_Total).Caption("Tổng").Width(90).Alignment(HorizontalAlignment.Center).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    }).Width(40).Alignment(HorizontalAlignment.Center).AllowSorting(false);

                                                    //column.Add().Caption("").Visible(false).Columns(a =>
                                                    //{
                                                    //    a.AddFor(m => m.TotalOverTimeValue.TotalSeconds).Width(90).Alignment(HorizontalAlignment.Center).AllowHeaderFiltering(false).AllowFiltering(false).AllowSorting(false);
                                                    //}).Width(40).Alignment(HorizontalAlignment.Center).Format("#,###").AllowSorting(false);

                                                }).ToDefaultOption().Editing(e => e.AllowAdding(false).AllowDeleting(false).AllowUpdating(false)).Grouping(grouping => grouping.AutoExpandAll(false))
                                                .SortByGroupSummaryInfo(i => i.Add().SummaryItem("count"))
                                                .Summary(s =>

                                                s.SkipEmptyValues(true).TotalItems(items =>
                                                {
                                                    items.AddFor(m => m.EmployeeNumber).SummaryType(SummaryType.Count).DisplayFormat(Vinorsoft_NHNN_Report_DevEx_App_Resource.Sumary_Total + " {0} ");
                                                   // items.AddFor(m => m.TotalOverTimeValue.TotalSeconds).SummaryType(SummaryType.Sum).ShowInColumn("User.FirstName").DisplayFormat(new JS("secondsToTime"));
                                                }).GroupItems(items =>
                                                {
                                                    items.Add()
                                                    .SummaryType(SummaryType.Count)
                                                    .DisplayFormat("{0}");
                                                })).Export(e => e.Enabled(true).AllowExportSelectedData(true).FileName($"{Vinorsoft_NHNN_Report_DevEx_App_Resource.Export_OverTime_FileName}__Tháng {Model.Month}-{Model.Year}")).OnFileSaving("OnFileSaving").OnToolbarPreparing("OnToolbarPreparing")
);

#line default
#line hidden
            EndContext();
            BeginContext(24370, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(24375, 47, false);
#line 225 "P:\KHMT\NHNN\Trunk\SubProject\NHNN\Vinorsoft.NHNN.Report\Vinorsoft.NHNN.Report.App\Areas\Report\Views\ReportOverTime\Index.cshtml"
Write(await Html.PartialAsync("_ProcessExcelScripts"));

#line default
#line hidden
            EndContext();
            BeginContext(24422, 465, true);
            WriteLiteral(@"

<script>
    function secondsToTime(seconds) {
        var hours = Math.floor(seconds / 3600),
            minutes = Math.floor((seconds - 3600 * hours) / 60),
            seconds = seconds - 60 * (60 * hours + minutes);

        if (hours < 10) hours = ""0"" + hours;
        if (minutes < 10) minutes = ""0"" + minutes;
        if (seconds < 10) seconds = ""0"" + seconds;

        return [hours, minutes].join("":"") + (""(Giờ:Phút)"");
    }
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SearchReportOverTimeDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
