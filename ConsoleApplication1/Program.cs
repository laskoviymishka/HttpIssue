using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	using System.Diagnostics;
	using System.Net.Http;

	class Program
	{
		private static string test =
			@"{""moduleName"":""C:\\Users\\Andrei_Tserakhau\\AppData\\Local\\Temp\\tmp42BD.tmp"",""exportedFunctionName"":""renderToString"",""args"":[""C:\\dev\\Source\\Repos\\NodeServices\\templates\\Angular2Spa"",{""moduleName"":""ClientApp/boot-server"",""exportName"":null,""webpackConfig"":""webpack.config.js""},""http://localhost:5000/counter"",""/counter""]}";
		public static void Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();

			sw.Start();

			for (int i = 0; i < 20; i++)
			{
				TestCall().Wait();
			}

			sw.Stop();

			Console.WriteLine("Total Elapsed={0} ms", sw.Elapsed.Milliseconds);
			Console.Read();
		}

		private async static Task TestCall()
		{
			Stopwatch sw = new Stopwatch();

			sw.Start();
			using (var client = new HttpClient())
			{
				var payload = new StringContent(test, Encoding.UTF8, "application/json");
				var response = await client.PostAsync("http://localhost:50202", payload);
			}

			sw.Stop();

			Console.WriteLine("Elapsed={0} ms", sw.Elapsed.Milliseconds);
		}
	}
}
