using System;
using Microsoft.Practices.ServiceLocation;

namespace FluentArchitecture.DependencyInjection
{
	public interface IDependencyInjectionRegistrationContext<out TRegistration> where TRegistration : class
	{
		void Register<T>();

		void Register(Type type);

		IServiceLocator Build();

		TRegistration Registration { get; }
	}
}