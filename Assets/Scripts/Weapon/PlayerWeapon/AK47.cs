using Character;
using UnityEngine;

namespace Weapon.PlayerWeapon
{
    public class Ak47 : IPlayerWeapon
    {
        public Ak47(GameObject gameObject, ICharacter owner) : base(gameObject, owner)
        {
        }
    }
}