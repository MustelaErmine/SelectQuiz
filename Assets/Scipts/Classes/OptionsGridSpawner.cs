using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuizData;
using QuizLogic;
using DG.Tweening;

namespace QuizDisplay
{
    public class OptionsGridSpawner : MonoBehaviour, IOptionsSpawner
    {
        public QuizLevel Level { get; set; }
        public ICompleteNotifyable CompleteNotifyable { get; set; }
        public IWinDisplayer WinDisplayer { get; set; }
        public ICodeNotifyable CodeNotifyable { get; set; }
        public string[] ExcludeCodes { get; set; }

        private List<GameObject> optionObjects = new List<GameObject>();

        public void Spawn()
        {
            GridQuizLevel gridLevel = (GridQuizLevel)Level;
            int total_amount = gridLevel.Rows * gridLevel.Columns;

            QuizOptionData[] options = Level.GetRange(total_amount);

            string rightCode = Level.ChooseCode(options, ExcludeCodes);
            CodeNotifyable.SetCode(rightCode);

            transform.position = Vector3.zero;

            float startX = (-gridLevel.Columns / 2f + 0.5f) * gridLevel.GridSize;
            float startY = (-gridLevel.Rows / 2f + 0.5f) * gridLevel.GridSize;

            for (int i = 0; i < gridLevel.Rows; i++)
            {
                for (int j = 0; j < gridLevel.Columns; j++)
                {
                    QuizOptionData optionData = options[i * gridLevel.Columns + j];
                    GameObject optionObject = Instantiate(Level.Atlas.DisplayPrefab, Vector3.zero, new Quaternion(0,0,0,0));
                    Transform optionTransform = optionObject.transform;

                    optionTransform.localScale = new Vector3(0.1f,0.1f,0.1f);
                    optionTransform.transform.DOScale(1, 1f).SetEase(Ease.InBounce);

                    optionTransform.position = new Vector2(
                        startX + j * gridLevel.GridSize,
                        startY + i * gridLevel.GridSize
                    );

                    QuizOption option = optionObject.GetComponent<QuizOption>();
                    option.CompleteNotifyable = CompleteNotifyable;
                    option.OptionData = optionData;
                    option.WinDisplayer = WinDisplayer;
                    option.IsRight = optionData.OptionText == rightCode;

                    IDisplayable displayable = (IDisplayable)option;

                    displayable.Display();

                    optionObjects.Add(optionObject);
                }
            }
        }

        public void ClearAll()
        {
            foreach(GameObject optionObject in optionObjects)
            {
                Destroy(optionObject);
            }
        }
    }
}