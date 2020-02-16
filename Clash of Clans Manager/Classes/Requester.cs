using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

// AM : #GL9PC029
// HTML : %23GL9PC029

namespace Clash_of_Clans_Manager.Classes
{
    class ClashOfClansServer
    {
        public const string BaseUrl = "https://api.clashofclans.com/v1/";
        public string Key { get; set; }
        public string EndPoint { get; set; }
        public ClashOfClansServer(string Key) => this.Key = Key;
    }

    public class Clan
    {
        public string Name { get; set; }
    }

    class Requester
    {
        static readonly HttpClient client = new HttpClient();
        public string Response { get; set; }

        public Requester()
        {
            //RunAsync().GetAwaiter().GetResult();
            //Task.Run(() => RunAsync().GetAwaiter().GetResult());
            //Console.WriteLine("CONST - RESPONSE : ");
            //Console.WriteLine(Response);
        }
        static async Task<Clan> GetClanAsync(string path)
        {
            Clan clan = null;
            //HttpResponseMessage response = await client.GetAsync(path);
            HttpResponseMessage response = await client.GetAsync(new Uri(path, UriKind.Relative));
            Console.WriteLine("RESPONSE : " + response);//DBG
            if (response.IsSuccessStatusCode)
            {
                clan = await response.Content.ReadAsAsync<Clan>();
            }
            return clan;
        }
        
        static async Task<string> GetStringAsync(Uri path)
        {
            var result = string.Empty;
            HttpResponseMessage response = await client.GetAsync(path);
            //HttpResponseMessage response = await client.GetAsync(new Uri(path, UriKind.Relative));
            //Console.WriteLine("RESPONSE : ");
            //Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }

        public async Task RunAsync()
        {
            var server = new ClashOfClansServer("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjA5M2ZkZWFkLWQ3NTUtNGRiMC1hMmI4LTkyZjUzZjQ0ZmJiYiIsImlhdCI6MTU4MTc5MzYxNCwic3ViIjoiZGV2ZWxvcGVyLzBkMTdjMmQ2LWUwMzMtNGNlOS00NTk0LWE2ZWI1YzlkY2M5OCIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjQxLjEwNC45OS4yMSJdLCJ0eXBlIjoiY2xpZW50In1dfQ.lY3K4CE6yZApCSwZuwyv4ARw8N2taNk7ZJ-io--jwm-ArxN9PKAa-eQn4MMC5pjMQ0vbv1O021pF9qgu4Rg9bw");
            //client.BaseAddress = new Uri(ClashOfClansServer.BaseUrl);
            client.BaseAddress = new Uri(ClashOfClansServer.BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", server.Key);
            //var clan = await GetClanAsync(ClashOfClansServer.BaseUrl + "clans/%23GL9PC029");
            //var str = await GetStringAsync("clans/%23GL9PC029");
            //var str = await GetStringAsync(new Uri(ClashOfClansServer.BaseUrl + "clans/%23GL9PC029"));

            //var clan = await GetClanAsync("clans/%23GL9PC029");
            //Console.WriteLine("------------------------------------------------------------------------------------------------");
            //Console.WriteLine("------------------------------------------------------------------------------------------------");
            //Console.WriteLine("------------------------------------------------------------------------------------------------");
            //Console.WriteLine("------------------------------------------------------------------------------------------------");
            //Console.WriteLine("RESULT : ");
            //Console.WriteLine(clan.name);

            try
            {

                //var str = Task.Run(() => GetStringAsync(new Uri(ClashOfClansServer.BaseUrl + "clans/%23GL9PC029")));
                //str.Wait();
                //Console.WriteLine(str.Result);

                Response = await GetStringAsync(new Uri(ClashOfClansServer.BaseUrl + "clans/%23GL9PC029"));
                //Console.WriteLine(Response);
                //var str = await GetStringAsync(new Uri(ClashOfClansServer.BaseUrl + "clans/%23GL9PC029"));
                //Console.WriteLine(str);




                //var clan = await GetClanAsync(url);
                //var clan = await GetClanAsync("clans");
                //var clan = await GetClanAsync(ClashOfClansServer.BaseUrl+"clans");
                //Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.WriteLine("RESULT : ");
                //Console.WriteLine(clan.name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void ShowServer()
        {

        }

    }


}