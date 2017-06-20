using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace codae.backend.ui.Extensions
{
    public static class ViewExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList<T, kproperty1, kproperty2>(this IEnumerable<T> items,
            Expression<Func<T, kproperty1>> name,
            Expression<Func<T, kproperty2>> value)
            where T: class
        {
            var list = new List<SelectListItem>();
            foreach (var item in items)
            {
                list.Add(new SelectListItem()
                {
                    Text = name.Compile().DynamicInvoke(item).ToString(),
                    Value = value.Compile().DynamicInvoke(item).ToString()
                });
            }

            return list;
        }
    }
}