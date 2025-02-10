using System.Collections.Generic;
using Factory;
using Property.ShareProperty;
using UnityEngine;
using Utility;

namespace Property.ScriptableObject
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData")]
    public class PlayerScriptableObject :UnityEngine.ScriptableObject
    {
        public List<PlayerAttr> playerAttrs = new ();
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