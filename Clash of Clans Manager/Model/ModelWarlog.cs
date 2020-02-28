using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfClansManager.Classes
{
    public class ClanWar
    {
        public WarClan Clan { get; set; }
        public int TeamSize { get; set; }
        public WarClan Opponent { get; set; }
        public string StartTime { get; set; }
        public string State { get; set; }
        public string EndTime { get; set; }
        public string PreparationStartTime { get; set; }

        public override string ToString()
        {
            return
$@"{nameof(Clan)} : {Clan}
{nameof(TeamSize)} : {TeamSize}
{nameof(Opponent)} : {Opponent}
{nameof(StartTime)} : {StartTime}
{nameof(State)} : {State}
{nameof(EndTime)} : {EndTime}
{nameof(PreparationStartTime)} : {PreparationStartTime}
";
        }
    }

    public class WarClan
    {
        public float DestructionPercentage { get; set; }
        public string Tag { get; set; }
        public string Name { get; set; }
        public BadgeUrls BadgeUrls { get; set; }
        public int ClanLevel { get; set; }
        public int Attacks { get; set; }
        public int Stars { get; set; }
        public int ExpEarned { get; set; }
        public IEnumerable<ClanWarMember> Members { get; set; }
//        public override string ToString()
//        {
//            return
//$@"{nameof(DestructionPercentage)} : {DestructionPercentage}
//{nameof(Tag)} : {Tag}
//{nameof(Name)} : {Name}
//{nameof(BadgeUrls)} : {BadgeUrls}
//{nameof(ClanLevel)} : {ClanLevel}
//{nameof(Attacks)} : {Attacks}
//{nameof(Stars)} : {Stars}
//{nameof(ExpEarned)} : {ExpEarned}
//{nameof(Members)} : {string.Join("", Members)}
//";
//        }
    }

    public class ClanWarMember
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int MapPosition { get; set; }
        public int TownhallLevel { get; set; }
        public int OpponentAttacks { get; set; }
        public ClanWarAttack BestOpponentAttack { get; set; }
        public IEnumerable <ClanWarAttack> Attacks { get; set; }
        public override string ToString()
        {
            return
$@"{nameof(Tag)} : {Tag}
{nameof(Name)} : {Name}
{nameof(MapPosition)} : {MapPosition}
{nameof(TownhallLevel)} : {TownhallLevel}
{nameof(OpponentAttacks)} : {OpponentAttacks}
{nameof(BestOpponentAttack)} : {BestOpponentAttack}

";
        }
    }

//{nameof(Attacks)} : {string.Join("", Attacks?.ToList()  )} #HERE IS THE BUG
//This works
//{nameof(Attacks)} : {string.Join("", Attacks?.Any() )}

    public class ClanWarAttack
    {
        public int Order { get; set; }
        public string AttackerTag { get; set; }
        public string DefenderTag { get; set; }
        public int Stars { get; set; }
        public int DestructionPercentage { get; set; }
        public override string ToString()
        {
            return
$@"{nameof(Order)} : {Order}
{nameof(AttackerTag)} : {AttackerTag}
{nameof(DefenderTag)} : {DefenderTag}
{nameof(Stars)} : {Stars}
{nameof(DestructionPercentage)} : {DestructionPercentage}
";
        }
    }

    public class ClanWarLog
    {
        public IEnumerable<ClanWarLogEntry> Items { get; set; }
        public override string ToString()
        {
            return
$@"{nameof(Items)} : {string.Join("", Items)}
";
        }
    }

    public class ClanWarLogEntry
    {
        public WarClan Clan { get; set; }
        public int TeamSize { get; set; }
        public WarClan Opponent { get; set; }
        public string EndTime { get; set; }
        public string Result { get; set; }
        public override string ToString()
        {
            return
$@"{nameof(TeamSize)} : {TeamSize}
{nameof(EndTime)} : {EndTime}
{nameof(Result)} : {Result}
";
            //These might have null members, so it fails the deserialization
            //{nameof(Clan)} : {Clan}
            //{nameof(Opponent)} : {Opponent}
        }
    }

}
