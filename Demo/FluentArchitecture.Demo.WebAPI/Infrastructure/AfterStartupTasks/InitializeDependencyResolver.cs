using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using FluentArchitecture.DependencyInjection;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.Demo.WebAPI.Infrastructure.AfterStartupTasks
{
	public class InitializeDependencyResolver : IAutofacResolutionTask
	{
		private readonly ILifetimeScope _lifetimeScope;

		public InitializeDependencyResolver(ILifetimeScope lifetimeScope)
		{
			_lifetimeScope = lifetimeScope;
		}

		public void Run(IDependencyInjectionResolutionContext<IContainer> context)
		{
			HttpConfiguration config = GlobalConfiguration.Configuration;
			config.DependencyResolver = new AutofacWebApiDependencyResolver(_lifetimeScope);
		}
	}
}