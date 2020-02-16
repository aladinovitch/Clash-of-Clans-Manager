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

    class Requester
    {
        static readonly HttpClient client = new HttpClient();
        public string Response { get; set; }

        static async Task<Clan> GetClanAsync(Uri path)
        {
            Clan clan = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            //HttpResponseMessage response = await client.GetAsync(new Uri(path, UriKind.Relative)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                clan = await response.Content.ReadAsAsync<Clan>().ConfigureAwait(false);
            }
            return clan;
        }
        
        static async Task<string> GetStringAsync(Uri path)
        {
            var result = string.Empty;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return result;
        }

        public async Task RunAsync()
        {
            var server = new ClashOfClansServer("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjcyOTcxYjVmLTNhZDAtNDUwYS1hMDA1LWVmNTAwYWQzYzI2MiIsImlhdCI6MTU4MTg5MDQ3Mywic3ViIjoiZGV2ZWxvcGVyLzBkMTdjMmQ2LWUwMzMtNGNlOS00NTk0LWE2ZWI1YzlkY2M5OCIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjQxLjEwNC4xMTIuMjA2Il0sInR5cGUiOiJjbGllbnQifV19.wexUlJ9x9VikBosDOSRuZBSEwibKkg44BCCx8hNkXRUtUqzhXLM2KZ-QtlQX5UD_o7vQ47JYcDWBPOMPesUfhQ");
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

            try
            {

                //Response = await GetStringAsync(new Uri(ClashOfClansServer.BaseUrl + "clans/%23GL9PC029")).ConfigureAwait(false);
                var clan = await GetClanAsync(new Uri(ClashOfClansServer.BaseUrl + "clans/%23GL9PC029")).ConfigureAwait(false);
                Response = clan.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void FormatResponse()
        {
        }

    }
}