using QuizData;

namespace QuizLogic 
{ 
    public interface ILevelImplementer
    {
        public QuizLevel[] Levels { set; get; }
        public void Restart();
    }
}