using System;
using Attribute;
using Factory;

namespace Property.ShareProperty
{
    [Serializable]
    public class WeaponAttr
    {
        [ReadOnly] public PlayerWeaponType type;
        [ReadOnly] public ItemQualityType quality;
        [ReadOnly] public int damage;
        [ReadOnly] public int magicSpend;
        [ReadOnly] public int fireRate;
        [ReadOnly] public PlayerBulletType bulletType;
        [ReadOnly] public float bulletSpeed;
    }
}