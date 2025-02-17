using UnityEngine;

namespace Item
{
    public class AbstractItem
    {
        #region Public
        
        public GameObject GameObject { get; set; }

        public void SetPosition(Vector3 pos)
        {
            Transform.position = pos;
        }

        public void SetRotation(Quaternion rot)
        {
            Transform.rotation = rot;
        }

        public void Remove()
        {
            OnExit();
        }

        public void GameUpdate()
        {
            OnUpdate();
        }


        #endregion

        #region Protected
 
        protected Transform Transform => GameObject.transform;

        protected AbstractItem(GameObject obj)
        {
            GameObject = obj;
        }

        protected virtual void OnUpdate()
        {
            if (!_isInit)
            {
                _isInit = true;
                OnInit();
            }
        }

        protected virtual void OnInit()
        {
            
        }

        protected virtual void OnExit()
        {
            
        }

        #endregion

        #region Private

        private bool _isInit;

        #endregion
    }
}