using Character;
using UnityEngine;

namespace Weapon.PlayerWeapon
{
    public class Ak47 : AbstractPlayerWeapon
    {
        public Ak47(GameObject gameObject, AbstractCharacter owner) : base(gameObject, owner)
        {
        }

        #region Protected

        protected override PlayerWeaponType WeaponType => PlayerWeaponType.Ak47;

        #endregion
    }
}