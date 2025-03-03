using System;
using Attribute;

namespace Property.ShareProperty
{
    [Serializable]
    public class EnemyShareAttr : CharacterShareAttr
    {
        [ReadOnly] public EnemyType type;
        [ReadOnly] public bool isElite;
        [ReadOnly] public EnemyWeaponType weaponType;
        [ReadOnly] public int damage;
        [ReadOnly] public int speed;
        [ReadOnly] public bool isIdleLeft;
    }
}