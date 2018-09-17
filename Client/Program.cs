using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace Client
{
    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();
        private static async Task MainAsync()
        {
            // discover endpoints from metadata
            var disco = await DiscoveryClient.GetAsync($"http://{Config.ISAddress}:{Config.ISPort}");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            while (true)
            {
                Console.WriteLine("Input username");
                var username = Console.ReadLine();
                Console.WriteLine("Input password");
                var pass = Console.ReadLine();
                // request token
                var tokenClient = new TokenClient(disco.TokenEndpoint, Config.ClientId, Config.ClientSecret);
                var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(username, pass, Config.ApiId);

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Json);
                    continue;
                }

                Console.WriteLine(tokenResponse.Json);
                Console.WriteLine("\n\n");
                //// call api
                //var client = new HttpClient();
                //client.SetBearerToken(tokenResponse.AccessToken);

                //var response = await client.GetAsync("http://localhost:5001/identity");
                //if (!response.IsSuccessStatusCode)
                //{
                //    Console.WriteLine(response.StatusCode);
                //}
                //else
                //{
                //    var content = response.Content.ReadAsStringAsync().Result;
                //    Console.WriteLine(JArray.Parse(content));
                //}
            }
        }
    }
}
