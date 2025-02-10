using System.Collections.Generic;
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
    }
}