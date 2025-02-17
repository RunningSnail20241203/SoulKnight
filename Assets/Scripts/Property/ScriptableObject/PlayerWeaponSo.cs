using System.Collections.Generic;
using Factory;
using Property.ShareProperty;
using UnityEngine;
using Utility;

namespace Property.ScriptableObject
{
    [CreateAssetMenu(fileName = FileName, menuName = "ScriptableObject/PlayerWeaponDef")]
    public class PlayerWeaponSo : UnityEngine.ScriptableObject
    {
        public const string FileName = "PlayerWeaponDef";
        public List<PlayerWeaponAttr> playerWeaponAttrs = new();
        public TextAsset textAsset;
        private void OnValidate()
        {
            UnityTool.Instance.WriteDataToList(playerWeaponAttrs, textAsset);
        }

        public PlayerWeaponAttr GetPlayerWeaponAttr(PlayerWeaponType playerWeaponType)
        {
            return playerWeaponAttrs.Find(attr => attr.type == playerWeaponType);
        }
    }
}