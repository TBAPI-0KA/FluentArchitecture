using System;
using Autofac;

namespace FluentArchitecture.DependencyInjection
{
	public class AutofacRegistrationContext : IDependencyInjectionRegistrationContext<ContainerBuilder>
	{
		private readonly ContainerBuilder _builder;

		public AutofacRegistrationContext()
		{
			_builder = new ContainerBuilder();
		}

		public void Register<T>()
		{
			_builder.RegisterType<T>();
		}

		public void Register(Type type)
		{
			_builder.RegisterType(type);
		}

		public IDependencyInjectionResolutionContext<TContainer> Build<TContainer>() where TContainer : class
		{
			IContainer container = _builder.Build();
			return (IDependencyInjectionResolutionContext<TContainer>)new AutofacResolutionContext(container);
		}

		public ContainerBuilder Registration
		{
			get
			{
				return _builder;
			}
		}
	}
}