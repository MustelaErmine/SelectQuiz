using QuizData;
using QuizLogic;

namespace QuizDisplay
{
    public interface IOptionsSpawner
    {
        public QuizLevel Level { get; set; }
        public ICompleteNotifyable CompleteNotifyable { get; set; }
        public IWinDisplayer WinDisplayer { get; set; }
        public ICodeNotifyable CodeNotifyable { get; set; }
        public string[] ExcludeCodes { get; set; }
        public void Spawn();
        public void ClearAll();
    }
}