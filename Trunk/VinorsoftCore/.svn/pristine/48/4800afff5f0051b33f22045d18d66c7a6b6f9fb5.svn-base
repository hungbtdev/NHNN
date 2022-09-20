using KTApps.Core.Utils;
using KTApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTApps.Models.Search
{
    public class Search
    {
        public string Value { set; get; }
        public bool Regex { set; get; }

    }
    public class Column
    {
        public string Data { set; get; }
        public string Name { set; get; }
        public bool Searchable { set; get; }
        public bool Orderable { set; get; }
        public Search Search { set; get; }

        public string WhereCondition
        {
            get
            {
                if (Searchable && !string.IsNullOrEmpty(Data) && !string.IsNullOrEmpty(Search.Value))
                {
                    if (Search.Value.Contains("~"))
                    {
                        var searchVals = Search.Value.Split("~").Where(e => !string.IsNullOrEmpty(e)).ToList();
                        if (searchVals.Count <= 0)
                        {
                            return string.Empty;
                        }
                        string minVal = string.Empty;
                        string maxVal = string.Empty;
                        // Max value
                        if (Search.Value.Trim().StartsWith("~"))
                        {
                            if (StringUtils.IsNumeric(searchVals[0]))
                            {
                                maxVal = searchVals[0];
                            }
                            else if (StringUtils.IsDate(searchVals[0], "yyyy-MM-dd"))
                            {
                                maxVal = $"Convert.ToDateTime(\"{searchVals[0]}\")";
                            }
                            return $"{Data} <= {maxVal}";
                        }
                        // Min value
                        else if (Search.Value.Trim().EndsWith("~"))
                        {
                            if (StringUtils.IsNumeric(searchVals[0]))
                            {
                                minVal = searchVals[0];
                            }
                            else if (StringUtils.IsDate(searchVals[0], "yyyy-MM-dd"))
                            {
                                minVal = $"Convert.ToDateTime(\"{searchVals[0]}\")";
                            }
                            return $"{Data} >= {minVal}";
                        }
                        // 
                        else if (searchVals.Count > 1)
                        {
                            if (StringUtils.IsNumeric(searchVals[0]))
                            {
                                minVal = searchVals[0];
                            }
                            else if (StringUtils.IsDate(searchVals[0], "yyyy-MM-dd"))
                            {
                                minVal = $"Convert.ToDateTime(\"{searchVals[0]}\")";
                            }

                            if (StringUtils.IsNumeric(searchVals[1]))
                            {
                                maxVal = searchVals[1];
                            }
                            else if (StringUtils.IsDate(searchVals[1], "yyyy-MM-dd"))
                            {
                                maxVal = $"Convert.ToDateTime(\"{searchVals[1]}\").AddDays(1).AddSeconds(-1)";
                            }
                            return string.Format($"{Data} <= {maxVal} and {Data} >= {minVal}");
                        }
                    }
                    else
                    {
                        return string.Format($"({ Data } != null and {Data}.ToString().ToLower().Contains(\"{Search.Value.ToLower()}\"))");
                    }
                }
                return string.Empty;
            }
        }
    }

    public class Order
    {
        public int Column { set; get; }
        public string Dir { set; get; }
    }

}
