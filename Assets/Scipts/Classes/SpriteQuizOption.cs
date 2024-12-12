using QuizData;
using UnityEngine;

namespace QuizDisplay
{
    public class SpriteQuizOption : QuizOption, IDisplayable
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        SpriteQuizOptionData spriteOption { get => (SpriteQuizOptionData)OptionData; }
        public void Display()
        {
            spriteRenderer.sprite = spriteOption.DisplaySprite;
            var props = spriteOption.DisplayProps;
            DisplayTransform.localScale = new Vector2(props.Size, props.Size);
            DisplayTransform.localEulerAngles = new Vector3(0f, 0f, props.Angle);
        }
    }
}