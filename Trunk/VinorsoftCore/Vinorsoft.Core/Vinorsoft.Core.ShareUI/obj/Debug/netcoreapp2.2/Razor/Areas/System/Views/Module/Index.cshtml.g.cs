#pragma checksum "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Module\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffe24cee5f49207fdef35cdb913b86d521619535"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_System_Views_Module_Index), @"mvc.1.0.view", @"/Areas/System/Views/Module/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/System/Views/Module/Index.cshtml", typeof(AspNetCore.Areas_System_Views_Module_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffe24cee5f49207fdef35cdb913b86d521619535", @"/Areas/System/Views/Module/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e89d903c5125a6a79e61c03c342c851b58031aab", @"/Areas/System/Views/_ViewImports.cshtml")]
    public class Areas_System_Views_Module_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(1, 40, false);
#line 1 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Module\Index.cshtml"
Write(await Component.InvokeAsync("FormTitle"));

#line default
#line hidden
            EndContext();
            BeginContext(41, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(47, 3486, false);
#line 3 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Module\Index.cshtml"
Write(Html.DevExtreme().DataGrid<CoreModuleDTO>()
                                                .DataSource(d => d.Mvc()
                                                    .Controller("Module")
                                                    .LoadAction("Get")
                                                    .InsertAction("Insert")
                                                    .UpdateAction("Update")
                                                    .DeleteAction("Delete")
                                                    .Key("Id")
                                                ).ToDefaultOption()
                                                .Columns(columns =>
                                                {
                                                    columns.AddFor(m => m.Id)
                                                    .Visible(false);

                                                    columns.AddFor(m => m.Code)
                                                    .Caption(Resources.CatalogueObject_Code)
                                                    ;

                                                    columns.AddFor(m => m.Name)
                                                    .Caption(Resources.CatalogueObject_Name)
                                                    ;

                                                    columns.AddFor(m => m.Position)
                                                   .Caption(Resources.CoreModule_Position)
                                                   .Width(80)
                                                   ;

                                                    columns.AddFor(m => m.Description)
                                                    .Caption(Resources.CatalogueObject_Description)
                                                    ;
                                                    columns.AddFor(m => m.Created)
                                                   .Caption(Resources.DomainObject_Created)
                                                   .Format("dd/MM/yyyy HH:mm:ss")
                                                   ;
                                                    columns.AddFor(m => m.CreatedBy)
                                                   .Caption(Resources.DomainObject_CreatedBy)
                                                   ;
                                                })
                                                .Editing(e =>
                                                    e.AllowAdding(true)
                                                    .AllowDeleting(true)
                                                    .AllowUpdating(true)
                                                    .Mode(GridEditMode.Batch)
                                                    .UseIcons(true)
                                                    .SelectTextOnEditStart(true)
                                                )

                                               .Selection(s => s.Mode(SelectionMode.Multiple))
                                               .Export(e => e.Enabled(true)
                                               .FileName($"{ViewData["Title"]}")
                                               .AllowExportSelectedData(true))
                                               .OnInitNewRow("onInitNewRow")
);

#line default
#line hidden
            EndContext();
            BeginContext(3534, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(3539, 44, false);
#line 57 "D:\NHNN\Trunk\VinorsoftCore\Vinorsoft.Core\Vinorsoft.Core.ShareUI\Areas\System\Views\Module\Index.cshtml"
Write(await Html.PartialAsync("_CatalogueScripts"));

#line default
#line hidden
            EndContext();
            BeginContext(3583, 4, true);
            WriteLiteral("\r\n\r\n");
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
