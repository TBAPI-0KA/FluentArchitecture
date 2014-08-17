using FluentArchitecture.Demo.WebUI.Infrastructure.AfterStartupTasks;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.Demo.WebUI
{
	public class MvcApplication : AutofacHttpApplication
	{
		protected MvcApplication()
		{
			AfterStartupTask<RegisterAreas>();
			AfterStartupTask<RegisterRoutes>();
		}
	}
}