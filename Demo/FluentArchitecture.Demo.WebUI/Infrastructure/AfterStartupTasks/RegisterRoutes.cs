using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using FluentArchitecture.DependencyInjection;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.Demo.WebUI.Infrastructure.AfterStartupTasks
{
	public class RegisterRoutes : IAutofacResolutionTask
	{
		public void Run(IDependencyInjectionResolutionContext<IContainer> context)
		{
			RouteCollection routes = RouteTable.Routes;

			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute
			(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}