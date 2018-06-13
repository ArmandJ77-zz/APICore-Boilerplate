namespace TestObjects.Infrastructure.ControllerEndpoints
{
    public static class BlogControllerEndpoints
    {
        public static string BaseRoute => "api/blogs";

        public static string Get(long id) => $"{BaseRoute}/{id}";
        public static string PagedList(int? pageSize, int? pageIndex) => $"{BaseRoute}/pagedlist?pageSize={pageSize}&pageIndex={pageIndex}";
        public static string List => $"{BaseRoute}/list";
        public static string Create => $"{BaseRoute}";
        public static string Update => $"{BaseRoute}";
        public static string Delete(long id) => $"{BaseRoute}/{id}";
    }
}
