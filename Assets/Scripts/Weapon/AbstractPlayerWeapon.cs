using Character;
using Character.Player;
using Command;
using Factory;
using Property.ShareProperty;
using UnityEngine;
using Utility;

namespace Weapon
{
    public class AbstractPlayerWeapon : AbstractWeapon
    {
        #region Public

        public PlayerWeaponShareAttr ShareAttr { get; set; }

        public bool IsUsed { get; private set; }

        public new AbstractPlayer Owner
        {
            get => base.Owner as AbstractPlayer;
            set => base.Owner = value;
        }

        public void ControlWeapon(bool isAttack)
        {
            if (isAttack && Time.time > _nextFireTime)
            {
                OnFire();
                _nextFireTime = Time.time + 1f / ShareAttr.fireRate;
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

        #region Protected

        protected virtual PlayerWeaponType WeaponType => PlayerWeaponType.None;

        async protected override void OnFire()
        {
            base.OnFire();
            var bullet = await BulletFactory.Instance.GetBullet(ShareAttr.bulletType);
            bullet.SetFlySpeed(ShareAttr.bulletSpeed);
            bullet.SetPosition(_firePoint.position);
            bullet.SetRotation(_rotOrigin.rotation);
            bullet.AddToController();
        }

        protected override void OnInit()
        {
            base.OnInit();
            _firePoint = UnityTool.Instance.FindTransformFromChildren(GameObject, "FirePoint");
            _rotOrigin = UnityTool.Instance.FindTransformFromChildren(GameObject, "RotOrigin");
            ShareAttr = WeaponCommand.Instance.GetAttr(WeaponType);
        }

        protected AbstractPlayerWeapon(GameObject gameObject, AbstractCharacter owner) : base(gameObject, owner)
        {

        }

        #endregion

        #region Private

        private bool _isAttack;
        private Transform _rotOrigin;
        private Transform _firePoint;
        private float _nextFireTime;

        #endregion
    }
}