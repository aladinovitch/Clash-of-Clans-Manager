using ClashOfClansManager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfClansManager.Model
{
    public class ViewModel
    {
        public string Token { get; set; }
        public Clan Clan { get; set; }
        public ClanWar CurrentWar { get; set; }
        public ClanWarLog ClanWarLog { get; set; }
        public string PlainText { get; set; }
    }
}
