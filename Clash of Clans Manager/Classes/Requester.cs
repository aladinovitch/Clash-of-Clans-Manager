using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Clash_of_Clans_Manager.Classes
{
    class ConstantNames
    {
        public const string Separator = "/";
        public const string Clan_AM_Tag = "#GL9PC029";
        public const string Clan_Sworn_Tag = "#2209GQ82J";
        public const string ClanEndPoint = "clans";
        public const string CurrentWarEndPoint = "currentwar";
        public const string WarLogEndPoint = "warlog";
    }
    class ClashOfClansServer
    {
        public string Key { get; set; } =
            "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImE3N2EyYTcyLWU0NjUtNDUzOS1iMWJiLTU2Nzc3ZjIyYzdhNyIsImlhdCI6MTU4MjE0MTAzNSwic3ViIjoiZGV2ZWxvcGVyLzBkMTdjMmQ2LWUwMzMtNGNlOS00NTk0LWE2ZWI1YzlkY2M5OCIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjQxLjEwNC4xOS42NiJdLCJ0eXBlIjoiY2xpZW50In1dfQ.JZ3Y_Eit997KRCwsm_Ld9sFJfBfGeYwuOXMZbZ5xVV3dF5AdA6COh8my9PWCQSiXDeJeVhKTSXVSDbYV801s9Q"
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
            ///Clan
            var clan = await RequestClanAsync(ConstantNames.Clan_Sworn_Tag).ConfigureAwait(false);
            Response = clan.ToString();

            ///Current war
            var currentWar = await RequestClanWarAsync(ConstantNames.Clan_Sworn_Tag).ConfigureAwait(false);
            Response = currentWar.ToString();

            //Warlog
            var clanWarLog = await RequestClanWarLogAsync(ConstantNames.Clan_Sworn_Tag).ConfigureAwait(false);
            Response = clanWarLog.ToString();
        }

        private async Task<Clan> RequestClanAsync(string clanTag)
        {
            server.EndPoint =
                ConstantNames.ClanEndPoint
                + ConstantNames.Separator
                + System.Net.WebUtility.UrlEncode(clanTag);
            var clan = await ClashOfClansServer.GetAsync<Clan>(server.UriEndPoint()).ConfigureAwait(false);
            return clan;
        }

        private async Task<ClanWar> RequestClanWarAsync(string clanTag)
        {
            server.EndPoint =
                ConstantNames.ClanEndPoint
                + ConstantNames.Separator
                + System.Net.WebUtility.UrlEncode(clanTag)
                + ConstantNames.Separator
                + ConstantNames.CurrentWarEndPoint;
            var currentWar = await ClashOfClansServer.GetAsync<ClanWar>(server.UriEndPoint()).ConfigureAwait(false);
            return currentWar;
        }

        private async Task<ClanWarLog> RequestClanWarLogAsync(string clanTag)
        {
            server.EndPoint =
                ConstantNames.ClanEndPoint
                + ConstantNames.Separator
                + System.Net.WebUtility.UrlEncode(clanTag)
                + ConstantNames.Separator
                + ConstantNames.WarLogEndPoint;
            var clanWarLog = await ClashOfClansServer.GetAsync<ClanWarLog>(server.UriEndPoint()).ConfigureAwait(false);
            return clanWarLog;
        }
    }
}