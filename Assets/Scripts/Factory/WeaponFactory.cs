using System;
using System.Threading.Tasks;
using Character;
using Singleton;
using UnityEngine;
using Weapon;
using Weapon.PlayerWeapon;
using Object = UnityEngine.Object;

namespace Factory
{
    public class WeaponFactory : Singleton<WeaponFactory>
    {
        private const string WeaponOriginPoint = "GunOriginPoint";

        public async Task<IPlayerWeapon> GetPlayerWeapon(PlayerWeaponType playerWeaponType, ICharacter owner)
        {
            var origin = UnityTool.Instance.GetComponentFromChildren<Transform>(owner.GameObject, WeaponOriginPoint);
            var weaponName = playerWeaponType.ToString();
            var weaponPrefab = await ResourceFactory.Instance.GetWeapon(weaponName);
            var weaponObj = Object.Instantiate(weaponPrefab, origin);
            weaponObj.name = weaponName;
            weaponObj.transform.localPosition = Vector3.zero;
            
            IPlayerWeapon ret = playerWeaponType switch
            {
                PlayerWeaponType.BadPistol => new BadPistol(weaponObj, owner),
                PlayerWeaponType.Ak47 => new Ak47(weaponObj, owner),
                _ => null
            };

            return ret;
        }
    }

    public enum PlayerWeaponType
    {
        BadPistol,
        Ak47,
    }
}