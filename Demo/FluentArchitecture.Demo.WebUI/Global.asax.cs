using FluentArchitecture.Demo.WebUI.Infrastructure.AfterStartupTasks;
using FluentArchitecture.MVC.Infrastructure.AfterStartupTasks;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.Demo.WebUI
{
	public class MvcApplication : AutofacHttpApplication
	{
		protected MvcApplication()
		{
			AfterStartupTask<InitializeDependencyResolver>();
			AfterStartupTask<RegisterAllAreas>();
			AfterStartupTask<RegisterRoutes>();
		}
	}
}