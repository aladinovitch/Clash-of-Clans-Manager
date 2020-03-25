using ClashOfClansManager.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClashOfClansManager.Classes
{
    class ConstantNames
    {
        public const string Separator = "/";
        public const string ClanEndPoint = "clans";
        public const string CurrentWarEndPoint = "currentwar";
        public const string WarLogEndPoint = "warlog";
    }
    class ClashOfClansServer
    {
        public string Key { get; set; }
        public const string BaseUrl = "https://api.clashofclans.com/v1/";
        static readonly HttpClient client = new HttpClient();
        public string EndPoint { get; set; }
        public ClashOfClansServer(string key)
        {
            Key = key;
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

        public string ClanTag { get; set; }
        private readonly ClashOfClansServer server;
        public Requester(string token)
        {
            server = new ClashOfClansServer(token);
        }

        public async Task<ViewModel> RunAsync(ViewModel vm)
        {
            ///Clan
            vm.Clan = await RequestClanAsync(ClanTag).ConfigureAwait(false);
            ///Current war
            vm.CurrentWar = await RequestClanWarAsync(ClanTag).ConfigureAwait(false);
            //Warlog
            vm.ClanWarLog = await RequestClanWarLogAsync(ClanTag).ConfigureAwait(false);
            return vm;
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