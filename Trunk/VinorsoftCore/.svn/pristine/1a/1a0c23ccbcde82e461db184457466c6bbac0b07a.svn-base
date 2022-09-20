using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;

namespace Vinorsoft.Core.NotiApp
{
    public static class HtmlEditorExtension
    {
        public static HtmlEditorBuilder ToDefaultToolbar(this HtmlEditorBuilder builder)
        {
            builder.Toolbar(toolbars =>
             {
                 toolbars.Items(toolbar =>
                 {
                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Undo);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Redo);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Separator);

                     toolbar.Add()
                         .FormatName("size")
                         .FormatValues(new[] { "8pt", "10pt", "12pt", "14pt", "18pt", "24pt", "36pt" });

                     toolbar.Add()
                         .FormatName("font")
                         .FormatValues(new[] { "Arial", "Courier New", "Georgia", "Impact", "Lucida Console", "Tahoma", "Times New Roman", "Verdana" });

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Separator);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Bold);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Italic);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Strike);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Underline);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Separator);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.AlignLeft);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.AlignCenter);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.AlignRight);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.AlignJustify);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Separator);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.OrderedList);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.BulletList);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Separator);

                     toolbar.Add().FormatName("header").FormatValues(new JS("[false, 1, 2, 3, 4, 5]"));

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Separator);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Color);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Background);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Separator);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Link);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Image);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Separator);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Clear);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.CodeBlock);

                     toolbar.Add().FormatName(HtmlEditorToolbarItem.Blockquote);
                 });

             });

            return builder;
        }
    }
}
