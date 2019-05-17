using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace deadjim
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            ProcessRepositories().Wait();
        }

        private static async Task ProcessRepositories()
        {
          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
          client.DefaultRequestHeaders.Add("User-Agent", ".NET deadjim");

          var stringTask = client.GetStringAsync("http://www.ideasyncratic.net");

          var msg = await stringTask;
          Console.Write(msg);
       }
    }
}
