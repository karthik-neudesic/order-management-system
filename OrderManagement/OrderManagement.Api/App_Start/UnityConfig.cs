using OrderManagement.Business.Implementation;
using OrderManagement.Business.Interfaces;
using OrderManagement.Repository.Implementation;
using OrderManagement.Repository.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace OrderManagement.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IOrderManager, OrderManager>();
            container.RegisterType<IOrderRepository, OrderRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}