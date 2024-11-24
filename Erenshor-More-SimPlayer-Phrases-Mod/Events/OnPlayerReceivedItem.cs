using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace Erenshor_More_SimPlayer_Phrases_Mod.Events
{
    public static class OnPlayerReceivedItem
    {
        public static List<SimPlayerPhrases.SimPlayerPhrase> Phrases { get; set; }
        public static Item lastItem;

        [HarmonyPatch(typeof(Inventory), "AddItemToInv", new Type[] { typeof(Item) })]
        private static class PatchItem
        {
            private static void Postfix(Item _item)
            {
                // Do OnPlayerCompletedQuest Event
                lastItem = _item;
                SimPlayerManager.ReactToEvent(Phrases, SimPlayerPhrases.SimPlayerPhraseEvent.OnPlayerReceivedItem);
            }
        }

        [HarmonyPatch(typeof(Inventory), "AddItemToInv", new Type[] { typeof(Item), typeof(int) })]
        private static class PatchItemInt
        {
            private static void Postfix(Item _item, int _qual)
            {
                // Do OnPlayerCompletedQuest Event
                lastItem = _item;
                SimPlayerManager.ReactToEvent(Phrases, SimPlayerPhrases.SimPlayerPhraseEvent.OnPlayerReceivedItem);
            }
        }
    }
}
