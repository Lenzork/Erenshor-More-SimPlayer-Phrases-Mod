using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace Erenshor_More_SimPlayer_Phrases_Mod.Events
{
    public class OnPlayerKilled
    {
        public static List<SimPlayerPhrases.SimPlayerPhrase> Phrases { get; set; }

        [HarmonyPatch(typeof(Stats), "ReduceHP")]
        private static class Patch
        {
            private static void Postfix(Stats __instance)
            {
                if (__instance.gameObject != GameObject.Find("Player")) return;

                if(__instance.CurrentHP <= 0)
                {
                    // Do OnPlayerRevived Event
                    SimPlayerManager.ReactToEvent(Phrases, SimPlayerPhrases.SimPlayerPhraseEvent.OnPlayerKilled);
                }
            }
        }
    }
}
