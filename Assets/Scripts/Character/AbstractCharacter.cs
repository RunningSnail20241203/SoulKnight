using UnityEngine;

namespace Character
{
    public abstract class AbstractCharacter
    {
        #region Private Data

        private bool _isLeft;
        private bool _isAlreadyRemove;
        private bool _isInit;
        private bool _isStart;

        #endregion

        #region Property

        public bool IsLeft
        {
            get => _isLeft;
            set
            {
                _isLeft = value;
                Transform.rotation = value ? Quaternion.Euler(0, 180f, 0) : Quaternion.identity;
            }
        }

        public GameObject GameObject { get; protected set; }
        public Transform Transform => GameObject.transform;

        #endregion

        protected AbstractCharacter(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }

        public void GameUpdate()
        {
            if (!_isInit)
            {
                _isInit = true;
                OnInit();
            }

            OnCharacterUpdate();
        }

        protected virtual void OnInit()
        {
        }

        protected virtual void OnCharacterStart()
        {
        }

        protected virtual void OnCharacterUpdate()
        {
            if (!_isStart)
            {
                _isStart = true;
                OnCharacterStart();
            }
        }

        protected virtual void OnCharacterDieStart()
        {
        }

        protected virtual void OnCharacterDieUpdate()
        {
        }
    }
}