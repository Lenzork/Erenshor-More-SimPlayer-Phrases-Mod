using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace Erenshor_More_SimPlayer_Phrases_Mod.Events
{
    public class OnPlayerCompletedQuest
    {
        public static List<SimPlayerPhrases.SimPlayerPhrase> Phrases { get; set; }
        public static string lastQuestName;

        [HarmonyPatch(typeof(GameData), "FinishQuest", new Type[] { typeof(string) })]
        private static class Patch
        {
            private static void Postfix(string _questName)
            {
                // Do OnPlayerCompletedQuest Event
                lastQuestName = _questName;
                SimPlayerManager.ReactToEvent(Phrases, SimPlayerPhrases.SimPlayerPhraseEvent.OnPlayerCompletedQuest);
            }
        }
    }
}
