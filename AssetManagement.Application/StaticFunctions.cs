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
    }
}
