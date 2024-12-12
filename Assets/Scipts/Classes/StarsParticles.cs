using UnityEngine;

namespace QuizUtils
{
    public class StarsParticles : MonoBehaviour, IDisplaysParticles
    {
        [SerializeField] ParticleSystem usedParticleSystem;
        new Transform transform;
        void Start()
        {
            transform = GetComponent<Transform>();
        }

        public void Display()
        {
            usedParticleSystem.Play();
        }
        public void DisplayHere(Vector2 position)
        {
            transform.position = position;
            Display();
        }
    }
}