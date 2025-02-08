using Character;
using UnityEngine;

namespace Weapon
{
    public class IPlayerWeapon : IWeapon
    {
        private bool _isAttack;
        private readonly Transform _rotOrigin;
        private bool _isUsed;

        #region Property

        public bool IsUsed => _isUsed;

        public new IPlayer Owner
        {
            get => base.Owner as IPlayer;
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
            _isUsed = true;
            GameObject.SetActive(true);
        }

        public void UnUseWeapon()
        {
            _isUsed = false;
            GameObject.SetActive(false);
        }

        #endregion
     
        protected IPlayerWeapon(GameObject gameObject, ICharacter owner) : base(gameObject, owner)
        {
            _rotOrigin = UnityTool.Instance.FindTransformFromChildren(gameObject, "RotOrigin", true);
        }
    }
}