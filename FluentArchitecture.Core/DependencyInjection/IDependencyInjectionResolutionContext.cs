using System;

namespace FluentArchitecture.DependencyInjection
{
	public interface IDependencyInjectionResolutionContext<out TContainer> where TContainer : class
	{
		T Resolve<T>();

		object Resolve(Type type);

		TContainer Container { get; }
	}
}