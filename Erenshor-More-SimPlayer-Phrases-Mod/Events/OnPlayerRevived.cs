using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace Erenshor_More_SimPlayer_Phrases_Mod.Events
{
    public class OnPlayerRevived
    {
        public static List<SimPlayerPhrases.SimPlayerPhrase> Phrases { get; set; }

        [HarmonyPatch(typeof(Respawn), "RespawnPlayer")]
        private static class Patch
        {
            private static void Postfix()
            {
                // Do OnPlayerRevived Event
                SimPlayerManager.ReactToEvent(Phrases, SimPlayerPhrases.SimPlayerPhraseEvent.OnPlayerRevived);
            }
        }
    }
}
