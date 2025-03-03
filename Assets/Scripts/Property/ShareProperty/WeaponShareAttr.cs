using System;
using Attribute;

namespace Property.ShareProperty
{
    [Serializable]
    public class WeaponShareAttr : AbstractShareAttr
    {
        [ReadOnly] public WeaponCategory category; // 武器种类
        [ReadOnly] public ItemQualityType quality; // 武器品质
        [ReadOnly] public int damage; // 伤害
        [ReadOnly] public int magicSpend; // 魔法消耗
        [ReadOnly] public float criticalRate; // 暴击率
        [ReadOnly] public float fireRate; // 射速
        [ReadOnly] public PlayerBulletType bulletType; // 子弹类型
        [ReadOnly] public float bulletSpeed; // 子弹速度
    }
}