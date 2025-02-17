using Character;
using Controller.MiddleRoom;
using Factory;
using Item.Bullet.PlayerBullet;
using Mediator;
using UnityEngine;
using Utility;

namespace Weapon
{
    public class AbstractPlayerWeapon : AbstractWeapon
    {
        #region Public

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
                _nextFireTime = Time.time + FireInterval;
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

        async protected override void OnFire()
        {
            base.OnFire();
            if (await BulletFactory.Instance.GetBullet(PlayerBulletType.Bullet5) is Bullet5 bullet)
            {
                bullet.SetPosition(_firePoint.position);
                bullet.SetRotation(_rotOrigin.rotation);
                bullet.AddToController();
            }
        }

        protected override void OnInit()
        {
            base.OnInit();
            _firePoint = UnityTool.Instance.FindTransformFromChildren(GameObject, "FirePoint");
            _rotOrigin = UnityTool.Instance.FindTransformFromChildren(GameObject, "RotOrigin");
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
        private const float FireInterval = 0.1f;

        #endregion
    }
}