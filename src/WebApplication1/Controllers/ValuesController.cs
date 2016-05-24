using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class Contract
	{
		public string Bar { get; set; }
		public string Foo { get; set; }
	}

	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		[HttpPost]
		public void Post([FromBody]Contract value)
		{
		}
	}
}
