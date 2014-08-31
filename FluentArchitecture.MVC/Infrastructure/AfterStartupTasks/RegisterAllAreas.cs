using System.Web.Mvc;
using FluentArchitecture.Web.Infrastructure;

namespace FluentArchitecture.MVC.Infrastructure.AfterStartupTasks
{
	public class RegisterAllAreas : IWebTask
	{
		public void Run()
		{
			AreaRegistration.RegisterAllAreas();
		}
	}
}