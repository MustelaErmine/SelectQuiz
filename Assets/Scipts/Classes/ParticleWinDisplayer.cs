using QuizUtils;
using UnityEngine;

namespace QuizDisplay
{
    public class ParticleWinDisplayer : MonoBehaviour, IWinDisplayer
    {
        [SerializeField] private Object displaysParticles;
        private IDisplaysParticles DisplaysParticles => (IDisplaysParticles) displaysParticles;
        public void Show()
        {
            Show(Vector2.zero);
        }

        public void Show(Vector2 position)
        {
            DisplaysParticles.DisplayHere(position);
        }
    }
}