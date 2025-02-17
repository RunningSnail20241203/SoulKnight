using System.Collections.Generic;
using Item.Bullet;

namespace Controller.MiddleRoom
{
    public class BulletController : AbstractController
    {
        #region Public 

        public void AddBullet(AbstractBullet bullet)
        {
            _bullets.Add(bullet);
        }

        #endregion


     

        protected override void AlwaysUpdate()
        {
            base.AlwaysUpdate();
            _bullets.RemoveAll(x => !x.GameObject);
            _bullets?.ForEach(x => x.GameUpdate());
        }
        
        private readonly List<AbstractBullet> _bullets = new();
    }
}