using System;

namespace FluentArchitecture.DependencyInjection
{
	public interface IDependencyInjectionRegistrationContext<out TRegistration> where TRegistration : class
	{
		void Register<T>();

		void Register(Type type);

		IDependencyInjectionResolutionContext<TContainer> Build<TContainer>() where TContainer : class;

		TRegistration Registration { get; }
	}
}