using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clash_of_Clans_Manager.Classes
{
    public class Clan
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public IconUrls BadgeUrls { get; set; }

        public override string ToString()
        {
            return
$@"{nameof(Tag)} : {Tag}
{nameof(Name)} : {Name}
{nameof(Type)} : {Type}
{nameof(Description)} : {Description}
{nameof(Location)} : {Location}
{nameof(BadgeUrls)} : {BadgeUrls}
";
        }
    }

    public class Location
    {
        public string LocalizedName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCountry { get; set; }
        public string CountryCode { get; set; }
        [JsonProperty("memberList")]
        public IEnumerable<Member> MemberList { get; set; }

        public override string ToString()
        {
            return
$@"{nameof(LocalizedName)} : {LocalizedName}
{nameof(Id)} : {Id}
{nameof(Name)} : {Name}
{nameof(IsCountry)} : {IsCountry}
{nameof(CountryCode)} : {CountryCode}
{nameof(MemberList)} : {MemberList}

";
        }
    }

    public class IconUrls
    {
        public Uri Small { get; set; }
        public Uri Medium { get; set; }
        public Uri Large { get; set; }

        public override string ToString()
        {
            return
$@"{nameof(Small)} : {Small}
{nameof(Medium)} : {Medium}
{nameof(Large)} : {Large}
";
        }
    }

    public class Member
    {
        public League League { get; set; }
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int ExpLevel { get; set; }
        public int ClanRank { get; set; }
        public int PreviousClanRank { get; set; }
        public int Donations { get; set; }
        public int DonationsRecieved { get; set; }
        public int Trophies { get; set; }
        public int VersusTrophies { get; set; }

        public override string ToString()
        {
            return
$@"{nameof(League)} : {League}
{nameof(Tag)} : {Tag}
{nameof(Name)} : {Name}
{nameof(Role)} : {Role}
{nameof(ExpLevel)} : {ExpLevel}
{nameof(ClanRank)} : {ClanRank}
{nameof(PreviousClanRank)} : {PreviousClanRank}
{nameof(Donations)} : {Donations}
{nameof(DonationsRecieved)} : {DonationsRecieved}
{nameof(Trophies)} : {Trophies}
{nameof(VersusTrophies)} : {VersusTrophies}
";
        }

    }

    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IconUrls IconUrls { get; set; }

        public override string ToString()
        {
            return
$@"{nameof(Id)} : {Id}
{nameof(Name)} : {Name}
{nameof(IconUrls)} : {IconUrls}
";
        }
    }
}
