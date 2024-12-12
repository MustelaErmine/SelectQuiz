using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuizData
{
    public abstract class QuizLevel : ScriptableObject
    {
        [SerializeField] QuizAtlas atlas;
        [SerializeField] GameObject spawnerPrefab;
        public GameObject SpawnerPrefab => spawnerPrefab;
        public QuizAtlas Atlas => atlas;
        public string ChooseCode(QuizOptionData[] range, string[] was_codes)
        {
            HashSet<string> was_codes_set = new HashSet<string>(was_codes);
            List<string> codes = new List<string>();

            foreach(QuizOptionData optionData in range)
            {
                if (!was_codes.Contains(optionData.OptionText))
                {
                    codes.Add(optionData.OptionText);
                }
            }
            string randomCode = codes[Random.Range(0, codes.Count)];
            return randomCode;
        }
        public QuizOptionData[] GetRange(int amount)
        {
            return atlas.Options.OrderBy(option => Random.value).Take(amount).ToArray();
        }
    } 
}