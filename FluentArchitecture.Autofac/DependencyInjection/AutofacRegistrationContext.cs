using System;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;

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

		public IServiceLocator Build()
		{
			IContainer container = _builder.Build();
			return new AutofacServiceLocator(container);
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