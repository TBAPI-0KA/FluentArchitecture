using System.Web.Http;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.Demo.WebAPI.Infrastructure.AfterStartupTasks
{
	public class RegisterRoutes : IWebTask
	{
		public void Run()
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