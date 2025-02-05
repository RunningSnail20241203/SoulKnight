namespace StateMachine
{
    public abstract class IState
    {
        protected readonly IStateMachine StateMachine;
        private bool _isInit;
        private bool _isEnter;

        protected IState(IStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void OnExit()
        {
            _isEnter = false;
        }

        public void GameUpdate()
        {
            if (!_isInit)
            {
                _isInit = true;
                OnInit();
            }
            OnUpdate();
        }

        protected virtual void OnUpdate()
        {
            if (!_isEnter)
            {
                _isEnter = true;
                OnEnter();
            }
        }
        
        
        

        protected virtual void OnEnter() { }
        protected virtual void OnInit(){}
        
    }
}