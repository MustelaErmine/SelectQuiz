using QuizData;

namespace QuizDisplay
{
    public interface IQuizOption
    {
        public QuizOptionData OptionData { set; get; }
        public bool IsRight { get; set; }
        public ICompleteNotifyable CompleteNotifyable { get; set; }
    }
}