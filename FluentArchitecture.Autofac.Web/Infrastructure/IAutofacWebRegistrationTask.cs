using Autofac;

namespace FluentArchitecture.Web.Infrastructure
{
	public interface IAutofacWebRegistrationTask : IWebRegistrationTask<ContainerBuilder>
	{
	}
}