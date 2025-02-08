using System;
using System.Collections.Generic;

namespace StateMachine
{
    public abstract class AbstractStateMachine : IDestroy
    {
        private readonly Dictionary<Type, AbstractState> _stateDic = new();
        private AbstractState _currentState;

        public void SetState<T>() where T : AbstractState
        {
            if (!_stateDic.ContainsKey(typeof(T)))
            {
                _stateDic.Add(typeof(T), (AbstractState)Activator.CreateInstance(typeof(T), this));
            }

            if (_currentState != null)
            {
                _currentState.OnExit();
            }
            _currentState = _stateDic[typeof(T)];
        }

        public void StopCurrentState()
        {
            _currentState?.OnExit();
        }

        public void GameUpdate()
        {
            if (_currentState != null)
            {
                _currentState.GameUpdate();
            }
        }

        public virtual void Destroy()
        {
            _stateDic.Clear();
        }
    }
}