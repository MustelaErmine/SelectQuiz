using System;
using UnityEngine;

namespace QuizUtils
{
    public interface IDisplaysParticles
    {
        public void Display();
        public void DisplayHere(Vector2 position);
    }
}