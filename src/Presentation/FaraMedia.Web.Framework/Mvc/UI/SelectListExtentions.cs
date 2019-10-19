namespace FaraMedia.Web.Framework.Mvc.UI {
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using FaraMedia.Core.Infrastructure.Extensions;

    public static class EnumerableExtentions {
        public static SelectList ToSelectList<T>(this IEnumerable<T> items, Expression<Func<T, object>> valueSelector, Expression<Func<T, string>> nameSelector, object selectedValue = null) {
            var selectList = new SelectList(items, valueSelector.GetMemberName(), nameSelector.GetMemberName(), selectedValue);

            return selectList;
        }
    }
}