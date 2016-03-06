using System;
using System.Web.Mvc;

namespace SuperheroManager.Web.Utilities
{
    public static class HtmlHelperExtensions
    {
        public static String ControllerName(this HtmlHelper helper)
        {
            return helper.ViewContext.RouteData.Values["controller"]?.ToString();
        }

        public static String ActionName(this HtmlHelper helper)
        {
            return helper.ViewContext.RouteData.Values["action"]?.ToString();
        }

        public static String ToggleClass(this HtmlHelper helper, String className, Func<Boolean> condition)
        {
            return condition() ? className : String.Empty;
        }
    }
}