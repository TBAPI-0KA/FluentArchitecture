using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.MVC.Infrastructure.AfterStartupTasks
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
			DependencyResolver.SetResolver(new AutofacDependencyResolver(_lifetimeScope));
		}
	}
}