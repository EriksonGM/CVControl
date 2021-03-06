﻿using System.Web.Mvc;

namespace CVControl.UI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Inicio", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}