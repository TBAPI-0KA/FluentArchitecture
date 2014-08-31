using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.WebAPI.Infrastructure.AfterStartupTasks
{
	public class InitializeDependencyResolver : IWebTask
	{
		private readonly ILifetimeScope _lifetimeScope;

		public InitializeDependencyResolver(ILifetimeScope lifetimeScope)
		{
			_lifetimeScope = lifetimeScope;
		}

		public void Run()
		{
			HttpConfiguration config = GlobalConfiguration.Configuration;
			config.DependencyResolver = new AutofacWebApiDependencyResolver(_lifetimeScope);
		}
	}
}