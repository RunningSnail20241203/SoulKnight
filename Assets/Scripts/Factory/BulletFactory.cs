using System.Threading.Tasks;
using Item.Bullet;
using Item.Bullet.PlayerBullet;
using Singleton;
using UnityEngine;

namespace Factory
{
    public class BulletFactory : Singleton<BulletFactory>
    {
        public async Task<AbstractBullet> GetBullet(PlayerBulletType bulletType)
        {
            var prefab = await ResourceFactory.Instance.GetBullet(bulletType.ToString());
            var obj = Object.Instantiate(prefab);
            return bulletType switch
            {
                PlayerBulletType.Bullet5 => new Bullet5(obj),
                _ => null
            };
        }
    }

    public enum PlayerBulletType
    {
        Bullet5,
    }
}