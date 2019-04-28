using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace MedsProcessor.WebAPI.Controllers
{
	[ApiController, ApiVersionNeutral]
	public class HomeController : ControllerBase
	{
		static bool isFirstTimeRun = true;

		/// <summary>
		/// Displays initial information about the Web API.
		/// </summary>
		/// <returns>Returns a JSON formatted message with basic Web API info.</returns>
		[HttpGet("~/")]
		public ObjectResult Index()
		{
			var sb = new StringBuilder();

			sb.AppendLine(isFirstTimeRun ?
					"The HZZO meds-processor has started with the Web API launch!" :
					"Welcome to the HZZO meds-processor.")
				.AppendLine($" You can check the status at: { Url.RouteUrl("Processor_GetStatus") }");

			isFirstTimeRun = false;

			return ApiHttpResponse.ForMessage(sb.ToString());
		}
	}
}