using KTApps.Core.App.Models;
using KTApps.Domain;
using System.Collections.Generic;
using System.Linq;

namespace KTApps.Core.App.Utilities
{
    public static class ListFilterExtension
    {
        public static IList<DropdownModel> ToFilterList<T>(this IEnumerable<T> items) where T : KTAppDomainCatalogue, new()
        {
            var result = items.Select(e => new DropdownModel()
            {
                Id = e.Id.ToString(),
                Name = e.Name
            }).ToList();
            result.Insert(0, new DropdownModel()
            {
                Id = string.Empty,
                Name = "-- Vui lòng chọn --"
            });

            return result;
        }
    }
}
