using Character;
using UnityEngine;

namespace Weapon
{
    public class AbstractWeapon : IDestroy
    {
        protected GameObject GameObject { get; set; }
        protected Transform Transform => GameObject.transform;
        protected AbstractCharacter Owner { get; set;}
        protected bool IsCanRotate { get; private set; } // 控制武器能否被旋转
        private bool _isInit;
        private bool _isEnter;

        protected AbstractWeapon(GameObject gameObject, AbstractCharacter owner)
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
        public virtual void Destroy()
        {
            Owner = null;
        }
    }
}