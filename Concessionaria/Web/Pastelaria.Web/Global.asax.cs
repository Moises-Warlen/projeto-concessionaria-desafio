﻿using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using System.Web.Routing;

namespace Concessionaria.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(SimpleInjectorContainer.RegisterServices()));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
