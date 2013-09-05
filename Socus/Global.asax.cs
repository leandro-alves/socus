using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Felice.Core;
using Felice.Data;
using Felice.Core.IoC;
using Felice.Mvc;
using Socus.Maps;

namespace Socus
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //// Inicializa felice framework
            FeliceCore.Initialize();
            
            Database.AddMigrations(typeof(MvcApplication).Assembly);
            Database.AddMappings(typeof(TratamentoMap).Assembly);
            Database.Initialize();

            Database.MigrateToLastVersion();

            DependencyResolver.SetResolver(new StructureMapDependencyResolver());
            FilterProviders.Providers.Add(new StructureMapFilterAttributeFilterProvider());

            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            GlobalFilters.Filters.Add(new UnitOfWorkFilter());

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}