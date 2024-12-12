using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizData
{
    public abstract class QuizOptionData : ScriptableObject
    {
        [SerializeField] protected string optionText;

        public string OptionText { get => optionText; }
    }
}