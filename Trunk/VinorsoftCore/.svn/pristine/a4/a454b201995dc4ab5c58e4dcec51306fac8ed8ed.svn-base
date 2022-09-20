using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KTApps.Core.Utils
{
    public static class ConvertDataExportUtils
    {
        public static byte[] GetByteExport<T>(this IList<T> items, string filePath) where T : class
        {
            ExcelUtility excelUtility = new ExcelUtility
            {
                TemplateFileData = File.ReadAllBytes(filePath)
            };
            return excelUtility.Export(items);
        }

        public static byte[] GetByteExport<T>(this IList<T> items, byte[] template) where T : class
        {
            ExcelUtility excelUtility = new ExcelUtility
            {
                TemplateFileData = template
            };
            return excelUtility.Export(items);
        }

        public static byte[] GetByteExport<T>(this IList<T> items, byte[] template, IDictionary<string, object> parameters) where T : class
        {
            ExcelUtility excelUtility = new ExcelUtility
            {
                TemplateFileData = template,
                ParameterData = parameters,
            };
            return excelUtility.Export(items);
        }
    }
}
