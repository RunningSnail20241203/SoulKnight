using System.Collections.Generic;
using Factory;
using Property.ShareProperty;
using UnityEngine;
using Utility;

namespace Property.ScriptableObject
{
    [CreateAssetMenu(fileName = FileName, menuName = "ScriptableObject/PlayerDef")]
    public class PlayerDataSo : UnityEngine.ScriptableObject
    {
        public const string FileName = "PlayerDef";
        public List<PlayerAttr> playerAttrs = new();
        public TextAsset textAsset;

        private void OnValidate()
        {
            UnityTool.Instance.WriteDataToList(playerAttrs, textAsset);
        }

        public PlayerAttr GetPlayerAttr(PlayerType playerType)
        {
            return playerAttrs.Find(attr => attr.type == playerType);
        }
    }
}