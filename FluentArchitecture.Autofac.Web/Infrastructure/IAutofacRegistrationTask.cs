using Autofac;

namespace FluentArchitecture.Web.Infrastructure
{
	public interface IAutofacRegistrationTask : IRegistrationTask<ContainerBuilder>
	{
	}
}