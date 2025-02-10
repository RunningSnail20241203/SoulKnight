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
        private bool _isSuspend;
        private GameObject _mainCanvas;
        private const string MainCanvasName = "MainCanvas";
        private bool _isDestroyed;

        #endregion

        #region Public API

        public void GameUpdate()
        {
            foreach (var child in Children)
            {
                child.GameUpdate();
            }

            if (!_isSuspend)
            {
                OnUpdate();
            }
        }

        public void EnterPanel()
        {
            TryInit();
            Resume();
        }

        #endregion

        #region Virtual Method

        protected virtual void OnInit()
        {
            _mainCanvas = UnityTool.Instance.FindGameObjectInScene(MainCanvasName);
            if (GameObject == null)
            {
                GameObject = UnityTool.Instance.FindGameObjectFromChildren(_mainCanvas, GetType().Name);
            }

            RectTransform = GameObject.GetComponent<RectTransform>();
        }

        protected virtual void OnResume()
        {

        }

        protected virtual void OnUpdate()
        {
        }

        protected virtual void OnSuspend()
        {

        }

        protected void Exit()
        {
            Suspend();

            _parent?.Resume();
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

        #endregion

        #region Private Method

        private void TryInit()
        {
            if (!_isInit)
            {
                _isInit = true;
                OnInit();
            }
        }

        private void Resume()
        {
            _isSuspend = false;
            GameObject.SetActive(true);
            OnResume();
        }

        private void Suspend()
        {
            _isSuspend = true;
            GameObject.SetActive(false);
            OnSuspend();
        }

        private T GetPanel<T>() where T : AbstractPanel
        {
            return Children.FirstOrDefault(x => x is T) as T;
        }

        #endregion

        #region Protected Method

        protected AbstractPanel(AbstractPanel parent)
        {
            _isSuspend = true;
            _parent = parent;
        }

        protected void EnterPanel<T>() where T : AbstractPanel
        {
            var panel = GetPanel<T>();
            panel.TryInit();
            panel.Resume();
            Suspend();
        }

        #endregion
    }
}