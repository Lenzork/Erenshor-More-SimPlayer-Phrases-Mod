using Erenshor_More_SimPlayer_Phrases_Mod.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Erenshor_More_SimPlayer_Phrases_Mod
{
    public class SimPlayerManager
    {
        public static List<GameObject> GetSimPlayers()
        {
            // Load all Bots
            SimPlayerMngr simBotManager = GameObject.Find("GameManager").GetComponent<SimPlayerMngr>();
            return simBotManager.ActualSims;
        }

        public static void ReactToEvent(List<SimPlayerPhrases.SimPlayerPhrase> phrases, SimPlayerPhrases.SimPlayerPhraseEvent simPlayerPhraseEvent)
        {
            List<GameObject> simPlayers = GetSimPlayers();
            List<SimPlayerPhrases.SimPlayerPhrase> simPlayerPhrases = phrases;
            List<SimPlayerPhrases.SimPlayerPhrase> simPlayerPhrasesForEvent = simPlayerPhrases.Where(x => x.Event == simPlayerPhraseEvent).ToList();

            GameObject randomSimPlayer = simPlayers[UnityEngine.Random.Range(0, simPlayers.Count)];

            SimPlayerPhrases.SimPlayerPhrase simPlayerPhrase = simPlayerPhrasesForEvent[UnityEngine.Random.Range(0, simPlayerPhrasesForEvent.Count)];
            
            if (UnityEngine.Random.Range(0.0f, 1f) > simPlayerPhrase.ChanceToReact)
            {
                return;
            }

            ReplaceVariables(ref simPlayerPhrase);

            UpdateSocialLog.LogAdd(randomSimPlayer.GetComponent<NPC>().NPCName + " shouts: " + simPlayerPhrase.Phrase, "orange");
        }

        private static void ReplaceVariables(ref SimPlayerPhrases.SimPlayerPhrase simPlayerPhrase)
        {
            Dictionary<string, string> variablePairs = new Dictionary<string, string>
            {
                { "%item%", OnPlayerReceivedItem.lastItem.ItemName },
                { "%questname%", OnPlayerCompletedQuest.lastQuestName },
                { "%playername%", GameObject.Find("Player").GetComponent<Stats>().MyName },
                { "%playerlevel%", GameObject.Find("Player").GetComponent<Stats>().Level.ToString() }
            };

            foreach (var variablePair in variablePairs)
            {
                simPlayerPhrase.Phrase = simPlayerPhrase.Phrase.Replace(variablePair.Key, variablePair.Value);
            }
        }
    }
}
