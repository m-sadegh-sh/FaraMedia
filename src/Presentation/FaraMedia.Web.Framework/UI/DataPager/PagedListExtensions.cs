namespace FaraMedia.Web.Framework.UI.DataPager {
    public static class PagedListExtensions {
        public static bool IsEmpty<T>(this PagedList<T> source) {
            return source == null || source.TotalPageCount == 0;
        }
    }
}