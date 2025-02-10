using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

namespace Panels
{
    public abstract class AbstractPanel : IDestroy
    {
        #region Property

        public Transform Transform => GameObject.transform;
        public RectTransform RectTransform { get; protected set; }
        protected List<AbstractPanel> Children { get; } = new();
        protected GameObject GameObject { get; private set; }

        #endregion

        #region Private Data

        private AbstractPanel _parent;
        private bool _isInit;
        private bool _isEnter;
        private bool _isSuspend;
        private readonly bool _isShowAfterExit;
        private GameObject _mainCanvas;
        private const string MainCanvasName = "MainCanvas";
        private bool _isDestroyed;

        #endregion

        #region Public API

        public void GameUpdate()
        {
            if (!_isInit)
            {
                _isInit = true;
                OnInit();
            }

            foreach (var child in Children)
            {
                child.GameUpdate();
            }

            if (!_isSuspend)
            {
                OnUpdate();
            }
        }

        public T GetPanel<T>() where T : AbstractPanel
        {
            return Children.FirstOrDefault(x => x is T) as T;
        }

        public void EnterPanel<T>() where T : AbstractPanel
        {
            var panel = GetPanel<T>();
            panel.Resume();
            Suspend();
        }

        public void Suspend()
        {
            _isSuspend = true;
            GameObject.SetActive(false);
        }

        public void Resume()
        {
            _isSuspend = false;
            GameObject.SetActive(true);
        }

        #endregion

        #region Virtual Method

        protected virtual void OnInit()
        {
            _isSuspend = true;

            _mainCanvas = UnityTool.Instance.FindGameObjectInScene(MainCanvasName);
            if (GameObject == null)
            {
                GameObject = UnityTool.Instance.FindGameObjectFromChildren(_mainCanvas, GetType().Name, true);
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

        protected void Exit()
        {
            if (!_isShowAfterExit)
            {
                GameObject.SetActive(false);
            }

            if (_parent != null)
            {
                _parent._isEnter = false;
                _parent.Resume();
            }

            Suspend();
        }

        #endregion

        protected AbstractPanel(AbstractPanel parent)
        {
            _parent = parent;
        }

        public virtual void Destroy()
        {
            if (_isDestroyed) return;
            _isDestroyed = true;
            
            foreach (var panel in Children)
            {
                panel.Destroy();
            }
            Children.Clear();

            _parent = null;
        }
    }
}