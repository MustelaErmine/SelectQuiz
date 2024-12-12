using System.Linq;
using UnityEngine;

namespace QuizData
{
    [CreateAssetMenu(fileName = "Atlas_", menuName = "QuizData/SpriteAtlas")]
    public class SpriteQuizAtlas : QuizAtlas
    {
        [SerializeField] SpriteQuizOptionData[] options;
        public override QuizOptionData[] Options
        {
            get => options;
        }
    }
}