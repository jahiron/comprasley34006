﻿using System.Web;
using System.Web.Mvc;

namespace Agenda_Personal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}