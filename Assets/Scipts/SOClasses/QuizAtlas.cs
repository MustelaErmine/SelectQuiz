using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuizData
{
    public abstract class QuizAtlas : ScriptableObject, IQuizAtlas
    {
        [SerializeField] GameObject displayPrefab;
        public virtual QuizOptionData[] Options { get => null; }
        public virtual List<QuizOptionData> OptionsList { get => Options.ToList(); }
        public virtual GameObject DisplayPrefab { get => displayPrefab; }
    }
}