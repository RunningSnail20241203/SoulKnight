using System;
using System.Threading.Tasks;
using Character;
using Singleton;
using UnityEngine;
using Utility;
using Weapon;
using Weapon.PlayerWeapon;
using Object = UnityEngine.Object;

namespace Factory
{
    public class WeaponFactory : Singleton<WeaponFactory>
    {
        private const string WeaponOriginPoint = "GunOriginPoint";

        public async Task<AbstractPlayerWeapon> GetPlayerWeapon(PlayerWeaponType playerWeaponType, AbstractCharacter owner)
        {
            var origin = UnityTool.Instance.FindTransformFromChildren(owner.GameObject, WeaponOriginPoint, true);
            var weaponName = playerWeaponType.ToString();
            var weaponPrefab = await ResourceFactory.Instance.GetWeapon(weaponName);
            var weaponObj = Object.Instantiate(weaponPrefab, origin);
            weaponObj.name = weaponName;
            weaponObj.transform.localPosition = Vector3.zero;
            
            AbstractPlayerWeapon ret = playerWeaponType switch
            {
                PlayerWeaponType.BadPistol => new BadPistol(weaponObj, owner),
                PlayerWeaponType.Ak47 => new Ak47(weaponObj, owner),
                _ => null
            };

            return ret;
        }
    }

   
}