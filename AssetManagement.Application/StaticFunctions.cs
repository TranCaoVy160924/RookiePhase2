using AssetManagement.Domain.Models;

namespace AssetManagement.Application
{
    public static class StaticFunctions<T> where T: class
    {
        public static List<T> Paging(IQueryable<T> records, int start, int end)
        {
            if(start < 0 || start > end)
            {
                start = 1;
            }
            if(end > records.Count())
            {
                end = records.Count();
            }
            return records.Skip(start).Take(end - start + 1).ToList();
        }

        public static IQueryable<Asset> Sort(IQueryable<T> dataList, string sort, string order)
        {
            sort = ConvertCamelToTitle(sort);
            System.Reflection.PropertyInfo prop = typeof(Asset).GetProperty(sort);
            //if (order == "ASC")
            //{
            //    return dataList
            //        .OrderBy(data => prop.GetValue(data) ?? string.Empty);
            //}
            //else
            //{
            //    return dataList
            //        .OrderByDescending(data => prop.GetValue(data) ?? string.Empty);
            //}

            if (order.Equals("ASC"))
            {
                return (IQueryable<Asset>)dataList
                    .OrderBy(data => prop.GetValue(data) ?? string.Empty)
                    .AsQueryable();
            }
            else
            {
                return (IQueryable<Asset>)dataList
                    .OrderByDescending(data => prop.GetValue(data) ?? string.Empty)
                    .AsQueryable();
            }
        }

        public static string ConvertCamelToTitle(string camelString)
        {
            string titleString = camelString.Substring(0, 1).ToUpper() + camelString.Substring(1);
            return titleString;
        }
    }
}
