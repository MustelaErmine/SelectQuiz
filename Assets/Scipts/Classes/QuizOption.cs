using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening.Core;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;
using System;
using QuizData;
using QuizUtils;

namespace QuizDisplay
{
    public abstract class QuizOption : MonoBehaviour, IQuizOption
    {
        public QuizOptionData OptionData { get; set; }
        public bool IsRight { get; set; }
        public ICompleteNotifyable CompleteNotifyable { get; set; }
        public IWinDisplayer WinDisplayer { get; set; }

        [SerializeField] GameObject displayObject;
        private Transform displayTransform;
        protected Transform DisplayTransform
        {
            get
            {
                if (displayTransform == null)
                {
                    displayTransform = displayObject.transform;
                }
                return displayTransform;
            }
        }

        public void OnClick()
        {
            if (CompleteNotifyable.IsWon)
                return;
            if (IsRight)
            {
                print("Right");
                DisplayRight().OnComplete(CompleteNotifyable.NotifyComplete);
            } 
            else
            {
                print("Not right");
                DisplayNotRight();
            }
        }
        void DisplayNotRight()
        {
            displayObject.transform.localPosition = Vector3.zero;
            displayObject.transform.DOShakePosition(duration: 1.4f, strength: new Vector3(1f, 0, 0), 
                vibrato: 5, randomness: 1, snapping: false, fadeOut: true, ShakeRandomnessMode.Harmonic).SetEase(Ease.InBounce);
        }
        Tween DisplayRight()
        {
            displayObject.transform.localPosition = Vector3.zero;
            Tween output = displayObject.transform.DOScale(1.7f * DisplayTransform.localScale.x, 1f).SetEase(Ease.InBounce);
            WinDisplayer.Show(DisplayTransform.position);
            return output;
        }
        void OnMouseDown()
        {
            OnClick();
        }
    }
}