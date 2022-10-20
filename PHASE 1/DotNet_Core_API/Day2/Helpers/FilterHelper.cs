namespace Day2.Helpers
{
    public static class FilterHelper
    {
        public static IEnumerable<T> GetPage<T>(IEnumerable<T> list, int pageIndex, int pageSize) 
        {
            return list.Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}