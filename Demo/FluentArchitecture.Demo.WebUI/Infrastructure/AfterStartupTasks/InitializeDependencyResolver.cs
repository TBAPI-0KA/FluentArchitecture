using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentArchitecture.DependencyInjection;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.Demo.WebUI.Infrastructure.AfterStartupTasks
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
			DependencyResolver.SetResolver(new AutofacDependencyResolver(_lifetimeScope));
		}
	}
}