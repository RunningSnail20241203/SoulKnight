using System;
using Attribute;
using Factory;

namespace Property.ShareProperty
{
    [Serializable]
    public class PlayerWeaponAttr : WeaponAttr
    {
     
    }

    public enum ItemQualityType
    {
        Gray,
        White,
        Green,
        Blue,
        Purple,
        Orange,
        Red,
    }
}