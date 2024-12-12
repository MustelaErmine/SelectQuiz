using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizData
{
    [CreateAssetMenu(fileName ="Option_", menuName ="QuizData/SpriteOption")]
    public class SpriteQuizOptionData : QuizOptionData
    {
        [SerializeField] protected Sprite displaySprite;
        [SerializeField] protected SpriteDisplayProps displayProps;

        public Sprite DisplaySprite { get => displaySprite; }
        public SpriteDisplayProps DisplayProps { get => displayProps; }
    }
}