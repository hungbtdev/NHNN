using KTApps.Core.Paging;
using KTApps.Domain;
using KTApps.Models;
using KTApps.Models.Import;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace KTApps.Core.Interface
{
    public interface ICatalogueService<E>: IDomainService<E> where E : KTAppDomainCatalogue
    {
        E GetByCode(string code);
        KTAppDomainImportResult Import(ImportDataModel importData);
    }
}
