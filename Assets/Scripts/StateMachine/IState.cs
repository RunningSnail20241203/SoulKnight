namespace StateMachine
{
    public abstract class IState
    {
        protected IStateMachine _stateMachine;
        private bool _isInit;
        private bool _isEnter;
        
        public IState(IStateMachine stateMachine)
        {
            this._stateMachine = stateMachine;
        }

        public virtual void OnExit()
        {
            _isEnter = false;
        }

        public virtual void OnUpdate()
        {
            if (!_isEnter)
            {
                _isEnter = true;
                OnEnter();
            }
        }
        
        
        

        protected virtual void OnEnter()
        {
            if (!_isInit)
            {
                _isInit = true;
                OnInit();
            }
        }
        protected virtual void OnInit(){}
        
    }
}