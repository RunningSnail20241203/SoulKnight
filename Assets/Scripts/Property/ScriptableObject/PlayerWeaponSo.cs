using System.Collections.Generic;
using Property.ShareProperty;
using UnityEngine;
using Utility;

namespace Property.ScriptableObject
{
    [CreateAssetMenu(fileName = FileName, menuName = "ScriptableObject/PlayerWeaponDef")]
    public class PlayerWeaponSo : UnityEngine.ScriptableObject
    {
        public const string FileName = "PlayerWeaponDef";
        public List<PlayerWeaponShareShareAttr> playerWeaponAttrs = new();
        public TextAsset textAsset;
        private void OnValidate()
        {
            UnityTool.Instance.WriteDataToList(playerWeaponAttrs, textAsset);
        }

        public PlayerWeaponShareShareAttr GetPlayerWeaponAttr(PlayerWeaponType playerWeaponType)
        {
            return playerWeaponAttrs.Find(attr => attr.type == playerWeaponType);
        }
    }
}