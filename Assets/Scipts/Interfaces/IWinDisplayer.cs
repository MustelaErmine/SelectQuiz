using UnityEngine;

namespace QuizDisplay
{
    public interface IWinDisplayer
    {
        public void Show();
        public void Show(Vector2 position);
    }
}