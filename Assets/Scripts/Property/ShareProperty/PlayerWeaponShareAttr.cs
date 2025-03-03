using System;
using Attribute;

namespace Property.ShareProperty
{
    [Serializable]
    public class PlayerWeaponShareAttr : WeaponShareAttr
    {
        [ReadOnly] public PlayerWeaponType type;
    }

   
}