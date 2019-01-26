using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TokenResponse = IdentityModel.Client.TokenResponse;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Program t = new Program();
         
            t.requestTokenAsync();

            Console.Read();
        }

        public async void requestTokenAsync()
        {
            // discover endpoints from metadata

            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5001/");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }

            // request token
            var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });

            if (response.IsError)
            {
                Console.WriteLine(response.Error);
            }

            Console.WriteLine(response.Json);
            CallAPIAsync( response);

        }

        public async void CallAPIAsync(TokenResponse tokenResponse)
        {
            // call api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:7002/api/TaskItems");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }

       
}
