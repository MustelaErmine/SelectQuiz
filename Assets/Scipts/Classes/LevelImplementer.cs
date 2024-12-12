using QuizData;
using QuizDisplay;
using System.Collections.Generic;
using UnityEngine;

namespace QuizLogic
{
    public class LevelImplementer : MonoBehaviour, ILevelImplementer, ICompleteNotifyable, ICodeNotifyable
    {
        [SerializeField] QuizLevel[] levels;
        public QuizLevel[] Levels { get => levels; set { levels = value; } }
        [SerializeField] Object doneHandler;
        [SerializeField] Object winDisplayer;
        [SerializeField] Object taskDisplayer;
        private IDoneHandler DoneHandler => (IDoneHandler) doneHandler;
        private IWinDisplayer WinDisplayer => (IWinDisplayer) winDisplayer;
        private ITaskDisplayer TaskDisplayer => (ITaskDisplayer) taskDisplayer;

        private IOptionsSpawner currentSpawner;

        private bool isWon = false;
        public bool IsWon => isWon;

        private int levelNow;
        private List<string> excludeCodes = new List<string>();


        void Start()
        {
            Restart();
            DoneHandler.LevelImplementer = this;
        }

        public void NotifyComplete()
        {
            levelNow++;
            if (levelNow < Levels.Length)
            {
                SpawnLevel(levelNow);
            } 
            else
            {
                DoneHandler.ProcessDone();
                isWon = true;
            }
        }

        public void Restart()
        {
            isWon = false;
            ClearAll();
            levelNow = 0;
            SpawnLevel(levelNow);
        }
        void ClearAll()
        {
            excludeCodes = new List<string>();
            ClearSpawner();
        }
        void ClearSpawner()
        {
            if (currentSpawner != null)
            {
                currentSpawner.ClearAll();
                currentSpawner = null;
            }
        }
        IOptionsSpawner InstantiateSpawner(GameObject prefab)
        {
            return Instantiate(prefab, Vector3.zero, Quaternion.identity).GetComponent<IOptionsSpawner>();
        }
        public void SpawnLevel(int position)
        {
            ClearSpawner();
            QuizLevel level = Levels[position];
            currentSpawner = InstantiateSpawner(level.SpawnerPrefab);
            currentSpawner.Level = level;
            currentSpawner.CompleteNotifyable = this;
            currentSpawner.WinDisplayer = WinDisplayer;
            currentSpawner.ExcludeCodes = excludeCodes.ToArray();
            currentSpawner.CodeNotifyable = this;
            currentSpawner.Spawn();
        }

        public void SetCode(string code)
        {
            excludeCodes.Add(code);
            TaskDisplayer.DisplayTask($"Find {code} there");
        }
    }
}