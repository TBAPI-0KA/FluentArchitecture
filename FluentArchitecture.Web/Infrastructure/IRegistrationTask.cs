using FluentArchitecture.DependencyInjection;

namespace FluentArchitecture.Web.Infrastructure
{
	public interface IRegistrationTask<in TRegistration> where TRegistration : class
	{
		void Run(IDependencyInjectionRegistrationContext<TRegistration> context);
	}
}