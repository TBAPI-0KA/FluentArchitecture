using System.Web.Http;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.WebAPI.Infrastructure.AfterStartupTasks
{
	public class CompleteInitialization : IWebTask
	{
		public void Run()
		{
			HttpConfiguration config = GlobalConfiguration.Configuration;
			config.EnsureInitialized();
		}
	}
}