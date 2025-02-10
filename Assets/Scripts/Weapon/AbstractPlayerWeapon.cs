using Character;
using UnityEngine;
using Utility;

namespace Weapon
{
    public class AbstractPlayerWeapon : AbstractWeapon
    {
        private bool _isAttack;
        private readonly Transform _rotOrigin;

        #region Property

        public bool IsUsed { get; private set; }

        public new AbstractPlayer Owner
        {
            get => base.Owner as AbstractPlayer;
            set => base.Owner = value;
        }

        #endregion

        #region Public API

        public void ControlWeapon(bool isAttack)
        {
            if (_isAttack != isAttack && isAttack)
            {
                OnFire();
                _isAttack = true;
            }
        }

        public void RotateWeapon(Vector2 dir)
        {
            if (IsCanRotate)
            {
                var angle = Vector3.SignedAngle(Transform.right, dir, Vector3.forward);
                angle *= Owner.IsLeft ? -1 : 1;
                _rotOrigin.localEulerAngles = new Vector3(0, 0, angle);
            }
            else
            {
                _rotOrigin.localEulerAngles = Vector3.zero;
            }
        }


        public void UseWeapon()
        {
            // Debug.Log($"UseWeapon:{this}");
            IsUsed = true;
            GameObject.SetActive(true);
        }

        public void UnUseWeapon()
        {
            // Debug.Log($"UnUseWeapon:{this}");
            IsUsed = false;
            GameObject.SetActive(false);
        }

        #endregion
     
        protected AbstractPlayerWeapon(GameObject gameObject, AbstractCharacter owner) : base(gameObject, owner)
        {
            _rotOrigin = UnityTool.Instance.FindTransformFromChildren(gameObject, "RotOrigin", true);
        }
    }
}