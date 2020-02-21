using Clash_of_Clans_Manager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clash_of_Clans_Manager.Model
{
    public class ViewModel
    {
        public Clan Clan { get; set; }
        public ClanWar CurrentWar { get; set; }
        public ClanWarLog ClanWarLog { get; set; }
    }
}
