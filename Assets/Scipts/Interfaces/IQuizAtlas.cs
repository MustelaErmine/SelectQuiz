using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizData
{
    public interface IQuizAtlas
    {
        public QuizOptionData[] Options { get; }
        public List<QuizOptionData> OptionsList { get; }
        public GameObject DisplayPrefab { get; }
    }
}