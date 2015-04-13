using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sandbox.Web.Utils
{
    public static class HtmlHelperExtensions
    {
        public static IEnumerable<SelectListItem> EnumSelectList<TEnum>(this HtmlHelper html, TEnum? selected = null)
            where TEnum : struct
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).OfType<TEnum>();
            var items = enumValues.Select(val => 
                                    SelectListItemFor<TEnum>(val, 
                                      selected.HasValue && selected.Value.Equals(val)));
            return items.ToList();
        }

        private static SelectListItem SelectListItemFor<TEnum>(TEnum value, bool selected)
            where TEnum : struct
        {
            var item = new SelectListItem();
            item.Text = value.ToString();
            item.Value = value.ToString();
            item.Selected = selected;
            return item;
        }
    }
}