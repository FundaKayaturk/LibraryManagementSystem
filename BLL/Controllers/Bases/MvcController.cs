using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Controllers.Bases
{
    public class MvcController : Controller
    {
        protected MvcController()
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

    }
}