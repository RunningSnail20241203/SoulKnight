using Character;
using UnityEngine;

namespace Weapon
{
    public class IWeapon
    {
        public GameObject GameObject { get; protected set; }
        public Transform Transform => GameObject.transform;
        protected ICharacter Owner { get; set;}
        private bool _isInit;
        private bool _isEnter;

        public IWeapon(GameObject gameObject, ICharacter owner)
        {   
            GameObject = gameObject;
            Owner = owner;
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
        protected virtual void OnEnter(){}

        protected virtual void OnExit()
        {
            _isEnter = false;
        }
        protected virtual void OnFire(){}
    }
}