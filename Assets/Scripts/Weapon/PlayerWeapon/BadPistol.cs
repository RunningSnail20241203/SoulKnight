using Character;
using UnityEngine;

namespace Weapon.PlayerWeapon
{
    public class BadPistol :IPlayerWeapon
    {
        public BadPistol(GameObject gameObject, ICharacter owner) : base(gameObject, owner)
        {
        }

        protected override void OnFire()
        {
            base.OnFire();
        }
    }
}