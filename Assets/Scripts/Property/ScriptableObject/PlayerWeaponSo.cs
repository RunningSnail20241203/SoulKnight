﻿using System.Collections.Generic;
using Property.ShareProperty;
using UnityEngine;
using Utility;

namespace Property.ScriptableObject
{
    [CreateAssetMenu(fileName = FileName, menuName = "ScriptableObject/PlayerWeaponDef")]
    public class PlayerWeaponSo : UnityEngine.ScriptableObject
    {
        public const string FileName = "PlayerWeaponDef";
        public List<PlayerWeaponShareAttr> attrs;
        public TextAsset textAsset;

        private void OnValidate()
        {
            UnityTool.Instance.WriteDataToList(attrs, textAsset);
        }

        public PlayerWeaponShareAttr GetAttr(PlayerWeaponType type)
        {
            return attrs.Find(attr => attr.type == type);
        }
    }
}