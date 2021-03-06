﻿using FluentArchitecture.DependencyInjection;

namespace FluentArchitecture.Web.Infrastructure
{
	public interface IWebRegistrationTask<in TRegistration> where TRegistration : class
	{
		void Run(IDependencyInjectionRegistrationContext<TRegistration> context);
	}
}