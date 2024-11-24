using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace Erenshor_More_SimPlayer_Phrases_Mod
{
    public class Mod : MelonMod
    {
        public override void OnLateInitializeMelon()
        {
            SimPlayerPhrases.LoadJson();
            SimPlayerPhrases.PutPhrasesToTheEvents();
        }
    }
}
