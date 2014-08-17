using System.Web.Http;
using Autofac;
using FluentArchitecture.DependencyInjection;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.Demo.WebAPI.Infrastructure.AfterStartupTasks
{
	public class RegisterRoutes : IAutofacResolutionTask
	{
		public void Run(IDependencyInjectionResolutionContext<IContainer> context)
		{
			HttpConfiguration config = GlobalConfiguration.Configuration;
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}