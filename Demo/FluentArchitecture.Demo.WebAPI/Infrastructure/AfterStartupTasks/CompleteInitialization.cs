using System.Web.Http;
using Autofac;
using FluentArchitecture.DependencyInjection;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.Demo.WebAPI.Infrastructure.AfterStartupTasks
{
	public class CompleteInitialization : IAutofacResolutionTask
	{
		public void Run(IDependencyInjectionResolutionContext<IContainer> context)
		{
			HttpConfiguration config = GlobalConfiguration.Configuration;
			config.EnsureInitialized();
		}
	}
}