using System;
using System.Collections.Generic;

namespace StateMachine
{
    public abstract class AbstractStateMachine : IDestroy
    {
        #region Public

        public void GameUpdate()
        {
            if (CurrentState != null)
            {
                CurrentState.GameUpdate();
            }
            OnUpdate();
        }

        public virtual void Destroy()
        {
            _stateDic.Clear();
        }

        #endregion

        #region Protected

        protected AbstractState CurrentState;
        protected virtual void OnUpdate()
        {

        }
        
        protected void SetState<T>() where T : AbstractState
        {
            if (!_stateDic.ContainsKey(typeof(T)))
            {
                _stateDic.Add(typeof(T), (AbstractState)Activator.CreateInstance(typeof(T), this));
            }

            CurrentState?.Exit();
            CurrentState = _stateDic[typeof(T)];
        }

        #endregion

        #region Private

        private readonly Dictionary<Type, AbstractState> _stateDic = new();

        #endregion
    }
}