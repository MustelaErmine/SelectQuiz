namespace QuizDisplay
{
    public interface ICompleteNotifyable
    {
        public void NotifyComplete();
        public bool IsWon { get; }
    }
}