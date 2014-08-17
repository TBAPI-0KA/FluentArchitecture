using FluentArchitecture.DependencyInjection;

namespace FluentArchitecture.Web.Infrastructure
{
	public interface IResolutionTask<in TContainer> where TContainer : class
	{
		void Run(IDependencyInjectionResolutionContext<TContainer> context);
	}
}