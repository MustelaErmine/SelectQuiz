using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace QuizLogic
{
    public class RestartDoneHandler : MonoBehaviour, IDoneHandler
    {
        [SerializeField] CanvasGroup group;
        [SerializeField] Button restartButton;

        public ILevelImplementer LevelImplementer { get; set; }

        private bool isWon = false;
        public bool IsWon => isWon;

        private Tween fadeOut;

        void Start()
        {
            group.alpha = 0f;
            group.blocksRaycasts = false;
            group.interactable = false;
        }
        public void ProcessDone()
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(RestartClicked);

            fadeOut = group.DOFade(1f, 0.5f).SetEase(Ease.OutQuart);
            fadeOut.OnComplete(() =>
            {
                group.blocksRaycasts = true;
                group.interactable = true;
            });
        }
        public void RestartClicked()
        {
            fadeOut?.Complete();
            isWon = false;

            LevelImplementer.Restart();
            group.alpha = 0f;
            group.blocksRaycasts = false;
            group.interactable = false;
        }
    }
}