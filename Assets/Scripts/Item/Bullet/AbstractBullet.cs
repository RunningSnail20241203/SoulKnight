using Controller.MiddleRoom;
using Mediator;
using UnityEngine;

namespace Item.Bullet
{
    public class AbstractBullet : AbstractItem
    {
        #region Public API

        public void AddToController()
        {
            GameMediator.Instance.GetController<BulletController>().AddBullet(this);
        }

        public void SetFlySpeed(float speed)
        {
            _speed = speed;
        }
        
        #endregion


        #region Protected

        protected AbstractBullet(GameObject obj) : base(obj)
        {

        }
        
        protected override void OnExit()
        {
            base.OnExit();
            Object.Destroy(GameObject);
        }

        protected virtual void OnHitObstacle()
        {
            
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Transform.position += Transform.right * (_speed * Time.deltaTime);
            if(Physics2D.OverlapCircle(Transform.position, 0.1f, LayerMask.GetMask(ObstacleLayer)))
            {
                OnHitObstacle();
                Remove();
            }
        }

        #endregion

        #region Private

        private float _speed = 30f;
        private const string ObstacleLayer = "Obstacle";

        #endregion
        
    }
}