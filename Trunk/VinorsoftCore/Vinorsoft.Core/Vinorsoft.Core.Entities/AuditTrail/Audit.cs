using System;
using System.Collections.Generic;
using System.Text;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{

    public class Audit : VinorsoftDomain
    {
        public string AuditType { get; set; }           /*Create, Update or Delete*/
        public string AuditUser { get; set; }           /*Log User*/
        public string TableName { get; set; }           /*Table where rows been 
                                                          created/updated/deleted*/
        public string KeyValues { get; set; }           /*Table Pk and it's values*/
        public string OldValues { get; set; }           /*Changed column name and old value*/
        public string NewValues { get; set; }           /*Changed column name 
                                                          and current value*/
        public string ChangedColumns { get; set; }      /*Changed column names*/
    }
}
