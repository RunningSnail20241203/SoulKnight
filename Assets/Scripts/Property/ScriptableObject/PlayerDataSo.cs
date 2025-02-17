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
        public List<PlayerShareAttr> playerAttrs = new();
        public TextAsset textAsset;

        private void OnValidate()
        {
            UnityTool.Instance.WriteDataToList(playerAttrs, textAsset);
        }

        public PlayerShareAttr GetPlayerAttr(PlayerType playerType)
        {
            return playerAttrs.Find(attr => attr.type == playerType);
        }
    }
}