using UnityEngine;

namespace QuizData
{
    [CreateAssetMenu(fileName = "Level_", menuName = "QuizData/GridLevel")]
    public class GridQuizLevel : QuizLevel
    {
        [SerializeField] int cols, rows;
        [SerializeField] float gridSize;
        public int Columns { get => cols; }
        public int Rows { get => rows; }
        public float GridSize { get => gridSize; }
    }
}