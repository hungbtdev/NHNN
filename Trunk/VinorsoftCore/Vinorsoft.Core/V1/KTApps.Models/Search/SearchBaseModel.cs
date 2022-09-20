using KTApps.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTApps.Models
{
    public interface IDomainSearchModel
    {
        int PageIndex { set; get; }
        int PageSize { set; get; }
        string SearchContent { set; get; }
        int Draw { set; get; }
        IList<Column> Columns { set; get; }
        IList<Order> Order { set; get; }
        int Start { set; get; }
        int Length { set; get; }
        Search.Search Search { set; get; }
        string WhereCondition { set; get; }
        string OrderBy { set; get; }
    }

    public abstract class DomainSearchModel : IDomainSearchModel
    {
        public DomainSearchModel()
        {
            Columns = new List<Column>();
            Order = new List<Order>();
        }

        public string SearchContent { set; get; }
        public int Start { set; get; }
        public int Length { set; get; }

        public int Draw { set; get; }
        public IList<Column> Columns { set; get; }
        public IList<Order> Order { set; get; }
        public Search.Search Search { set; get; }
        public int _PageIndex;
        public int PageIndex
        {
            get
            {
                if (Length > 0)
                {
                    _PageIndex = Start / Length + 1;
                }
                return _PageIndex;
            }
            set
            {
                _PageIndex = value;
            }
        }

        int _PageSize;
        public int PageSize
        {
            get
            {
                if (Length > 0)
                {
                    _PageSize = Length;
                }
                return _PageSize;
            }
            set
            {
                _PageSize = value;
            }
        }

        string _OrderBy;
        public string OrderBy
        {
            get
            {
                string result = string.Empty;
                if (Order.Where(e => !string.IsNullOrEmpty(Columns[e.Column].Data)).Count() > 0)
                {
                    _OrderBy = string.Join(",", Order.Where(e => !string.IsNullOrEmpty(Columns[e.Column].Data)).Select(e => Columns[e.Column].Data + " " + e.Dir));
                }
                if (string.IsNullOrEmpty(_OrderBy))
                {
                    _OrderBy = Columns.Where(e => !string.IsNullOrEmpty(e.Data) && e.Searchable).Select(e => e.Data).FirstOrDefault();
                }
                return _OrderBy;
            }
            set
            {
                _OrderBy = value;
            }
        }

        string _WhereCondition;
        public string WhereCondition
        {
            get
            {
                var conditions = Columns.Where(e => !string.IsNullOrEmpty(e.WhereCondition)).Select(e => e.WhereCondition).Distinct();
                if (conditions.Count() > 0)
                {
                    _WhereCondition = string.Join(" and ", conditions) + " and !Deleted";
                }
                else if (string.IsNullOrEmpty(_WhereCondition))
                {
                    _WhereCondition = "!Deleted";
                }
                return _WhereCondition;
            }
            set
            {
                _WhereCondition = value;
            }
        }
    }
}
