using System;
using Autofac;

namespace FluentArchitecture.DependencyInjection
{
	public class AutofacResolutionContext : IDependencyInjectionResolutionContext<IContainer>
	{
		private readonly IContainer _container;

		public AutofacResolutionContext(IContainer container)
		{
			_container = container;
		}

		public T Resolve<T>()
		{
			return _container.Resolve<T>();
		}

		public object Resolve(Type type)
		{
			return _container.Resolve(type);
		}

		public IContainer Container
		{
			get
			{
				return _container;
			}
		}
	}
}