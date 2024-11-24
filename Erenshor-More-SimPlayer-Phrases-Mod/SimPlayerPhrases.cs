using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erenshor_More_SimPlayer_Phrases_Mod.Events;
using Newtonsoft.Json;
using MelonLoader;

namespace Erenshor_More_SimPlayer_Phrases_Mod
{
    public class SimPlayerPhrases
    {
        public enum SimPlayerPhraseEvent
        {
            OnPlayerLevelUp,
            OnPlayerKilled,
            OnPlayerRevived,
            OnPlayerCompletedQuest,
            OnPlayerReceivedItem
        }

        public struct SimPlayerPhrase
        {
            public string Phrase { get; set; }
            public SimPlayerPhraseEvent Event { get; set; }
            public float ChanceToReact { get; set; }
        }

        private static List<SimPlayerPhrase> Phrases { get; set; }

        public static void LoadAllPhrases(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            Phrases = JsonConvert.DeserializeObject<List<SimPlayerPhrase>>(jsonContent);
            MelonLogger.Msg($"Loaded {Phrases.Count} Phrases.");
        }

        public static void LoadJson()
        {
            // Load Json File using Newtonsoft.Json
            string filePath = "SimPlayerPhrases.json";
            if (File.Exists(filePath))
            {
                LoadAllPhrases(filePath);
            }
            else
            {
                MelonLogger.Warning($"The specified JSON file was not found: {filePath}. Creating a sample one.");
                CreateSampleJson();
            }
        }

        public static void CreateSampleJson()
        {
            // Create Sample Json File using Newtonsoft.Json
            string filePath = "SimPlayerPhrases.json";
            if (File.Exists(filePath))
            {
                MelonLogger.Msg("Sample Json File already exists.");
                return;
            }

            var samplePhrases = new List<SimPlayerPhrase>
            {
                new SimPlayerPhrase
                {
                    Phrase = "Congratulations %playername% on leveling up to level %playerlevel%!",
                    Event = SimPlayerPhraseEvent.OnPlayerLevelUp,
                    ChanceToReact = 0.5f
                },
                new SimPlayerPhrase
                {
                    Phrase = "%playername% has been killed!",
                    Event = SimPlayerPhraseEvent.OnPlayerKilled,
                    ChanceToReact = 0.7f
                },
                new SimPlayerPhrase
                {
                    Phrase = "%playername% has been revived!",
                    Event = SimPlayerPhraseEvent.OnPlayerRevived,
                    ChanceToReact = 0.6f
                },
                new SimPlayerPhrase
                {
                    Phrase = "%playername% completed the Quest %questname% successfully!",
                    Event = SimPlayerPhraseEvent.OnPlayerCompletedQuest,
                    ChanceToReact = 0.8f
                },
                new SimPlayerPhrase
                {
                    Phrase = "%playername% has looted %item%, did you see that?",
                    Event = SimPlayerPhraseEvent.OnPlayerReceivedItem,
                    ChanceToReact = 0.6f
                }
            };

            string jsonContent = JsonConvert.SerializeObject(samplePhrases, Formatting.Indented);
            File.WriteAllText(filePath, jsonContent);
            MelonLogger.Msg("Sample Json File created successfully.");
            LoadAllPhrases(filePath);
        }

        public static void PutPhrasesToTheEvents()
        {
            // Initialisieren Sie die Listen in den Ereignisklassen
            OnPlayerLevelUp.Phrases = new List<SimPlayerPhrase>();
            OnPlayerKilled.Phrases = new List<SimPlayerPhrase>();
            OnPlayerRevived.Phrases = new List<SimPlayerPhrase>();
            OnPlayerCompletedQuest.Phrases = new List<SimPlayerPhrase>();
            OnPlayerReceivedItem.Phrases = new List<SimPlayerPhrase>();

            foreach (SimPlayerPhrase phrase in Phrases)
            {
                switch (phrase.Event)
                {
                    case SimPlayerPhraseEvent.OnPlayerLevelUp:
                        OnPlayerLevelUp.Phrases.Add(phrase);
                        break;
                    case SimPlayerPhraseEvent.OnPlayerKilled:
                        OnPlayerKilled.Phrases.Add(phrase);
                        break;
                    case SimPlayerPhraseEvent.OnPlayerRevived:
                        OnPlayerRevived.Phrases.Add(phrase);
                        break;
                    case SimPlayerPhraseEvent.OnPlayerCompletedQuest:
                        OnPlayerCompletedQuest.Phrases.Add(phrase);
                        break;
                    case SimPlayerPhraseEvent.OnPlayerReceivedItem:
                        OnPlayerReceivedItem.Phrases.Add(phrase);
                        break;
                    default:
                        MelonLogger.Error($"Unknown Event: {phrase.Event}");
                        break;
                }
            }
        }
    }
}
