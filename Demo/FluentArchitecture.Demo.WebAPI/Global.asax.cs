using FluentArchitecture.Demo.WebAPI.Infrastructure.AfterStartupTasks;
using FluentArchitecture.Web.Infrastructure;
using FluentArchitecture.WebAPI.Infrastructure.AfterStartupTasks;

namespace FluentArchitecture.Demo.WebAPI
{
	public class WebApiApplication : AutofacHttpApplication
	{
		public WebApiApplication()
		{
			AfterStartupTask<RegisterRoutes>();
			AfterStartupTask<CompleteInitialization>();
			AfterStartupTask<InitializeDependencyResolver>();
		}
	}
}