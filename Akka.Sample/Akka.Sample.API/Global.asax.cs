using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Akka.Actor;

namespace Akka.Sample.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected static ActorSystem ActorSystem;
        //here you would store your toplevel actor-refs
        protected static IActorRef MyActor;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ActorSystem = ActorSystem.Create("app");
            //here you would register your toplevel actors
            MyActor = ActorSystem.ActorOf<MyActor>();
        }
    }
}
