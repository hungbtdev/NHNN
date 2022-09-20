using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace KTApps.Core.Paging
{
    public class PagedList<T> where T : class
    {

        public PagedList()
        {

        }

        protected IQueryable<T> query;
        public PagedList(IQueryable<T> query)
        {
            this.query = query;
            Items = new List<T>();
        }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
        public int TotalPage { set; get; }
        public int TotalItem { set; get; }
        public IList<T> Items { set; get; }

        public void ToPage(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            decimal count = query.Count();
            TotalPage = (int)Math.Ceiling(count / pageSize);
            TotalItem = (int)count;
            int skip = (pageIndex - 1) * pageSize;
            int take = pageSize;
            Items = query.Skip(skip).Take(pageSize).ToList();
        }
        public async Task ToPageAsync(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            decimal count = await query.CountAsync();
            TotalPage = (int)Math.Ceiling(count / pageSize);
            TotalItem = (int)count;
            int skip = (pageIndex - 1) * pageSize;
            int take = pageSize;
            Items = await query.Skip(skip).Take(pageSize).ToListAsync();
        }

        public void ToPage(int pageIndex, int pageSize, string orderBy)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            decimal count = query.Count();
            TotalPage = (int)Math.Ceiling(count / pageSize);
            TotalItem = (int)count;
            int skip = (pageIndex - 1) * pageSize;
            int take = pageSize;
            Items = query.OrderBy(orderBy).Skip(skip).Take(pageSize).ToList();
        }

        public async Task ToPageAsync(int pageIndex, int pageSize, string orderBy)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            decimal count = await query.CountAsync();
            TotalPage = (int)Math.Ceiling(count / pageSize);
            TotalItem = (int)count;
            int skip = (pageIndex - 1) * pageSize;
            int take = pageSize;
            Items = await query.OrderBy(orderBy).Skip(skip).Take(pageSize).ToListAsync();
        }
    }
}
