namespace QuizLogic
{
    public interface IDoneHandler
    {
        public ILevelImplementer LevelImplementer { set; get; }
        public void ProcessDone();
    }
}