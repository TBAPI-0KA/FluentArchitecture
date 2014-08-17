using Autofac;
using FluentArchitecture.DependencyInjection;

namespace FluentArchitecture.Web.Infrastructure
{
	public abstract class AutofacHttpApplication : FluentHttpApplication<AutofacRegistrationContext, AutofacResolutionContext, ContainerBuilder, IContainer>
	{
	}
}