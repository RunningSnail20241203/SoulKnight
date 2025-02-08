using Character;
using UnityEngine;

namespace Weapon
{
    public class IWeapon
    {
        public GameObject GameObject { get; protected set; }
        public Transform Transform => GameObject.transform;
        protected ICharacter Owner { get; set;}
        protected bool IsCanRotate { get; private set; } // 控制武器能否被旋转
        private bool _isInit;
        private bool _isEnter;

        protected IWeapon(GameObject gameObject, ICharacter owner)
        {   
            GameObject = gameObject;
            Owner = owner;
            IsCanRotate = true;
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

        public void Enter()
        {
            
        }

        public void Exit()
        {
            OnExit();
        }
        
        protected virtual void OnInit(){}

        protected virtual void OnUpdate()
        {
            if (!_isEnter)
            {
                _isEnter = true;
                OnEnter();
            }
        }

        protected virtual void OnEnter()
        {
        }

        protected virtual void OnExit()
        {
            _isEnter = false;
        }
        protected virtual void OnFire(){}
    }
}