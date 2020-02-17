using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// AM: #GL9PC029 ; HTML: %23GL9PC029
//Sworn PvP: #2209GQ82J ; HTML: %232209GQ82J

namespace Clash_of_Clans_Manager.Classes
{
    class ClashOfClansServer
    {
        public string Key { get; set; } =
            "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6Ijg1MzEyZWEwLTk1YjUtNDIyMC1iOGJjLTAyNzhiMTYzZTRhNSIsImlhdCI6MTU4MTk3MDg2Niwic3ViIjoiZGV2ZWxvcGVyLzBkMTdjMmQ2LWUwMzMtNGNlOS00NTk0LWE2ZWI1YzlkY2M5OCIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjQxLjEwNS4xOTMuNTEiXSwidHlwZSI6ImNsaWVudCJ9XX0.QOTuOSZNnN9fGosKnrtJl7vQ_wmJ9RaiUPlRkK67jp7vb4JPvnfkPzdJyKf-raeGpNYJ7GuK-nMNUQw2ZfbZzw"
            ;
        public const string BaseUrl = "https://api.clashofclans.com/v1/";
        static readonly HttpClient client = new HttpClient();
        public string EndPoint { get; set; }
        public ClashOfClansServer()
        {
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Key);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<T> GetAsync<T>(Uri path)
        {
            T result = default;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>().ConfigureAwait(false);
            }
            return result;
        }

        public static async Task<string> GetAsStringAsync(Uri path)
        {
            var result = string.Empty;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return result;
        }

        public Uri UriEndPoint()
        {
            return new Uri(EndPoint, UriKind.Relative);
        }
    }

    //Connectors
    class Requester
    {
        //1. Clan
        //2. CurrentWar
        //3.Members
        //warLog
        //LeagueGroup

        private readonly ClashOfClansServer server = new ClashOfClansServer();
        public string Response { get; set; }

        public async Task RunAsync()
        {
            server.EndPoint = "clans/%23GL9PC029";
            var clan = await ClashOfClansServer.GetAsync<Clan>(server.UriEndPoint()).ConfigureAwait(false);
            Response = clan.ToString();

        }


    }
}