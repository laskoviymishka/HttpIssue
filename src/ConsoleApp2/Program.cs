using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	using System.Diagnostics;
	using System.IO;
	using System.Net;
	using System.Net.Http;
	using System.Text;

	public class Program
    {
		private static string test =
			 @"{""foo"":""dafgdsfgsdfg"",""bar"":""fddfsafdsf""}";
		public static void Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();
			Console.ReadKey();
			sw.Start();

			for (int i = 0; i < 20; i++)
			{
				TestCall().Wait();
			}

			sw.Stop();

			Console.WriteLine("Total Elapsed={0} ms", sw.Elapsed.TotalMilliseconds);
			Console.Read();
		}

		private async static Task TestCall()
		{
			Stopwatch sw = new Stopwatch();

			sw.Start();
			var request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/values");
			var postData = test;
			var data = Encoding.ASCII.GetBytes(postData);
			request.Method = "POST";
			request.ContentType = "application/json";
			using (var stream = await request.GetRequestStreamAsync())
				stream.Write(data, 0, data.Length);
			var response = (HttpWebResponse)await request.GetResponseAsync();

			sw.Stop();

			Console.WriteLine("Elapsed={0} ms", sw.Elapsed.TotalMilliseconds);
		}
	}
}
