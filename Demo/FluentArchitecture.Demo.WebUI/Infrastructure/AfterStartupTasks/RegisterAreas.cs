using System.Web.Mvc;
using Autofac;
using FluentArchitecture.DependencyInjection;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.Demo.WebUI.Infrastructure.AfterStartupTasks
{
	public class RegisterAreas : IAutofacResolutionTask
	{
		public void Run(IDependencyInjectionResolutionContext<IContainer> context)
		{
			AreaRegistration.RegisterAllAreas();
		}
	}
}