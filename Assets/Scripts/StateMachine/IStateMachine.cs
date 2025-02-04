using System;
using System.Collections.Generic;

namespace StateMachine
{
    public abstract class IStateMachine
    {
        private Dictionary<Type, IState> _stateDic;
        private IState _currentState;

        public IStateMachine()
        {
            _stateDic = new Dictionary<Type, IState>();
        }

        public void SetState<T>() where T : IState
        {
            if (!_stateDic.ContainsKey(typeof(T)))
            {
                _stateDic.Add(typeof(T), (IState)Activator.CreateInstance(typeof(T), this));
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
                _currentState.OnUpdate();
            }
        }
    }
}