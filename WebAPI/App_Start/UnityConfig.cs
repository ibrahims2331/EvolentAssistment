using System;
using Unity;
using Unity.WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents() {
            var container = new UnityContainer();


            // Register all your componets with the container here 

            container.RegisterType<Contract.IContact, Repository.ContactRepo>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}