namespace Mediator
{
    public class GameMediator : AbstractMediator
    {
        private static GameMediator _instance;

        public static GameMediator Instance
        {
            get { return _instance ??= new GameMediator(); }
        }
    }
}