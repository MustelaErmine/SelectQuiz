using TMPro;
using UnityEngine;

namespace QuizDisplay
{
    public class TextTaskDisplayer : MonoBehaviour, ITaskDisplayer
    {
        [SerializeField] TextMeshProUGUI textMesh;
        public void DisplayTask(string task)
        {
            textMesh.text = task;
        }
    }
}