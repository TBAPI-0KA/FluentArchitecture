using FluentArchitecture.Demo.WebAPI.Infrastructure.AfterStartupTasks;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.Demo.WebAPI
{
	public class WebApiApplication : AutofacHttpApplication
	{
		public WebApiApplication()
		{
			AfterStartupTask<RegisterRoutes>();
			AfterStartupTask<CompleteInitialization>();
		}
	}
}