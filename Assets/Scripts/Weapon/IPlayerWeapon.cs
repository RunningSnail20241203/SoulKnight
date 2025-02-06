using Character;
using UnityEngine;

namespace Weapon
{
    public class IPlayerWeapon : IWeapon
    {
        public IPlayer Player
        {
            get => Owner as IPlayer;
            set => Owner = value;
        }

        public IPlayerWeapon(GameObject gameObject, ICharacter owner) : base(gameObject, owner)
        {
        }
    }
}