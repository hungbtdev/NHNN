using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Vinorsoft.Core.App.Extensions
{
    public static class Extensions
    {
        public static T SetPropObjectNull<T>(this T obj) where T : class
        {
            foreach (var p in obj.GetType().GetProperties())
            {
                if (p.PropertyType.IsClass)
                    p.SetValue(obj, null);
            }
            return obj;
        }

        public static string GetFullErrorMessage(this ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return string.Join(" ", messages);
        }

    }
}
