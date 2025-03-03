using System.Collections.Generic;
using Property.ShareProperty;
using UnityEngine;
using Utility;

namespace Property.ScriptableObject
{
    [CreateAssetMenu(fileName = FileName, menuName = "ScriptableObject/PlayerDef")]
    public class PlayerDataSo : UnityEngine.ScriptableObject
    {
        public const string FileName = "PlayerDef";
        public List<PlayerShareAttr> attrs;
        public TextAsset textAsset;

        private void OnValidate()
        {
            UnityTool.Instance.WriteDataToList(attrs, textAsset);
        }

        public PlayerShareAttr GetAttr(PlayerType type)
        {
            return attrs.Find(attr => attr.type == type);
        }
    }
}