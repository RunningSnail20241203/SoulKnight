using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Panels
{
    public abstract class IPanel
    {
        public GameObject GameObject { get; protected set; }
        public Transform Transform => GameObject.transform;
        public RectTransform RectTransform { get; protected set; }
        private readonly IPanel _parent;
        private readonly List<IPanel> _children = new();
        private bool _isInit;
        private bool _isEnter;
        private bool _isSuspend;

        private readonly bool _isShowAfterExit;

        protected IPanel(IPanel parent)
        {
            this._parent = parent;
        }

        public void GameUpdate()
        {
            if (!_isInit)
            {
                _isInit = true;
                OnInit();
            }

            foreach (var child in _children)
            {
                child.GameUpdate();
            }

            if (!_isSuspend)
            {
                OnUpdate();
            }
        }

        public T GetPanel<T>() where T : IPanel
        {
            return _children.FirstOrDefault(x => x is T) as T;
        }

        public void EnterPanel<T>() where T : IPanel
        {
            var panel = GetPanel<T>();
            panel.Resume();
            panel._isEnter = true;
            Suspend();
        }

        public void Suspend()
        {
            _isSuspend = true;
        }

        public void Resume()
        {
            _isSuspend = false;
        }

        protected virtual void OnInit()
        {
            Suspend();
            if (GameObject == null)
            {
                GameObject = GameObject.Find(GetType().Name);
            }

            RectTransform = GameObject.GetComponent<RectTransform>();
        }

        protected virtual void OnEnter()
        {
        }

        protected virtual void OnUpdate()
        {
            if (!_isEnter)
            {
                _isEnter = true;
                OnEnter();
            }
        }

        protected virtual void OnExit()
        {
            if (!_isShowAfterExit)
            {
                GameObject.SetActive(false);
            }

            _parent._isEnter = false;
            _parent.Resume();
            Suspend();
        }
    }
}