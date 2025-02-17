using Controller.MiddleRoom;
using Factory;
using Item.Effect;
using UnityEngine;

namespace Item.Bullet.PlayerBullet
{
    public class Bullet5 : PlayerBullet
    {
        public Bullet5(GameObject obj) : base(obj)
        {
        }

        async protected override void OnHitObstacle()
        {
            base.OnHitObstacle();
            var pos = Transform.position;
            var effect = await EffectFactory.Instance.GetEffect<EffectBoom>();
            effect.SetPosition(pos);
            effect.AddToController();
        }
    }
}