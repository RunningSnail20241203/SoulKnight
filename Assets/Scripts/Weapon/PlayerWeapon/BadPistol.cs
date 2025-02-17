using Character;
using UnityEngine;

namespace Weapon.PlayerWeapon
{
    public class BadPistol : AbstractPlayerWeapon
    {
        public BadPistol(GameObject gameObject, AbstractCharacter owner) : base(gameObject, owner)
        {
        }

        #region Protected

        protected override PlayerWeaponType WeaponType => PlayerWeaponType.BadPistol;

        #endregion
    }
}