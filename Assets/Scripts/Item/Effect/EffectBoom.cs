using UnityEngine;
using Utility;

namespace Item.Effect
{
    public class EffectBoom : AbstractEffectBoom
    {
        public EffectBoom(GameObject obj) : base(obj)
        {
        }

        #region Protected

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (_animator.gameObject.activeSelf)
            {
                _stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
                if (_stateInfo.normalizedTime >= 1f)
                {
                    _animator.gameObject.SetActive(false);
                }
            }
            
            _timer += Time.deltaTime;
            if (_timer > DestroyTime)
            {
                Remove();
            }
        }

        protected override void OnInit()
        {
            base.OnInit();
            _animator = UnityTool.Instance.FindComponentFromChildren<Animator>(GameObject, "Sprite");
        }

        #endregion

   
        

        #region Private

        private float _timer;
        private const float DestroyTime = 1f;
        private Animator _animator;
        private AnimatorStateInfo _stateInfo;

        #endregion
    }
}