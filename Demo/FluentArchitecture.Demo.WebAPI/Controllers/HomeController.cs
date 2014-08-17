using System.Web.Http;

namespace FluentArchitecture.Demo.WebAPI.Controllers
{
	public class HomeController : ApiController
	{
		public string Get()
		{
			return "Hello! Greetings from Web API.";
		}
	}
}