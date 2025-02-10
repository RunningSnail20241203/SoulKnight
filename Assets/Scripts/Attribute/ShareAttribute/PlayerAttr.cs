using System;
using Factory;

namespace Attribute.ShareAttribute
{
    [Serializable]
    public class PlayerAttr : CharacterAttr
    {
        public PlayerType playerType;
        public PlayerWeaponType initWeapon;
        public int armor;
    }
}