using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace DevExtreme.AspNet.Mvc
{
    public static class DevExtremeHelper
    {
        public static DataGridBuilder<T> ToDefaultOption<T>(this DataGridBuilder<T> dataGrid)
        {
            return dataGrid.RemoteOperations(true)
                                                        .WordWrapEnabled(true)
                                                        .DateSerializationFormat("yyyy-MM-ddTHH:mm:ssx")
                                                        .ShowBorders(true)
                                                        .ShowColumnHeaders(true)
                                                        .ShowColumnLines(true)
                                                        .ShowRowLines(true)
                                                        .FilterRow(f => f.Visible(true))
                                                        .HeaderFilter(f => f.Visible(true))
                                                        .GroupPanel(p => p.Visible(true))
                                                        .Height(600)
                                                        .ShowBorders(true)
                                                        .ColumnAutoWidth(true)
                                                        .Paging(paging =>  paging.PageSize(20))
                                                        .Pager(pager =>
                                                        {
                                                            pager.ShowPageSizeSelector(true);
                                                            pager.AllowedPageSizes(new[] { 20, 25, 50, 100 });
                                                            pager.ShowInfo(true);
                                                        })
                                                        .FocusedRowEnabled(true)
                                                        .Editing(e =>
                                                            e.AllowDeleting(true)
                                                            .Mode(GridEditMode.Form)
                                                            .AllowUpdating(true)
                                                            .UseIcons(true)
                                                            .SelectTextOnEditStart(true)
                                                        )
                                                        .ColumnChooser(cc => cc
                                                            .Enabled(true)
                                                            .AllowSearch(true)
                                                        )
                                                        .Width("100%")
                                                        .Height("100%")
                                                        .ColumnHidingEnabled(true)
                                                       .Selection(s => s.Mode(SelectionMode.Multiple))
                                                       .Export(e => e.Enabled(true)
                                                       .AllowExportSelectedData(true));
        }

        public static DataGridBuilder<T> ToCatalogueDefaultOption<T>(this DataGridBuilder<T> dataGrid) where T : CatalogueObjectDTO
        {
            return dataGrid.ToDefaultOption().Columns(columns =>
            {
                columns.AddFor(m => m.Id)
                .Visible(false);

                columns.AddFor(m => m.Code)
                .Caption(Resources.CatalogueObject_Code)
                ;

                columns.AddFor(m => m.Name)
                .Caption(Resources.CatalogueObject_Name)
                ;

                columns.AddFor(m => m.Description)
                .Caption(Resources.CatalogueObject_Description)
                ;

                columns.AddFor(m => m.Created)
                .Width(150)
               .Caption(Resources.DomainObject_Created)
               .Format("dd/MM/yyyy HH:mm:ss")
               ;
                columns.AddFor(m => m.CreatedBy)
                .Width(150)
               .Caption(Resources.DomainObject_CreatedBy)
               ;
            });
        }
    }
}
