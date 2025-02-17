using UnityEngine;

namespace StateMachine
{
    public abstract class AbstractState
    {
        #region Public 

        public void GameUpdate()
        {
            if (!_isInit)
            {
                _isInit = true;
                OnInit();
            }
            OnUpdate();
        }

        public void Exit()
        {
            OnExit();
        }
        #endregion


        #region Protected
        protected readonly AbstractStateMachine StateMachine;
        protected static readonly int IsRun = Animator.StringToHash("isRun");
        

        protected AbstractState(AbstractStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }


        protected virtual void OnUpdate()
        {
            if (!_isEnter)
            {
                _isEnter = true;
                OnEnter();
            }
        }
        protected virtual void OnEnter() {}
        protected virtual void OnInit() {}
        
        protected virtual void OnExit()
        {
            _isEnter = false;
        }

        #endregion

        #region Private

        private bool _isInit;
        private bool _isEnter;

        #endregion
    }
}