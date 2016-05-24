using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	using System.Diagnostics;
	using System.Net.Http;
	using System.Text;
	class Program
	{
		private static string test =
			@"{""foo"":""dafgdsfgsdfg"",""bar"":""fddfsafdsf""}";
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
				var response = await client.PostAsync("http://localhost:5000/api/values", payload);
			}

			sw.Stop();

			Console.WriteLine("Elapsed={0} ms", sw.Elapsed.Milliseconds);
		}
	}
}
