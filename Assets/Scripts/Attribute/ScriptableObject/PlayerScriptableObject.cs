using System.Collections.Generic;
using Attribute.ShareAttribute;
using UnityEngine;

namespace Attribute.ScriptableObject
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData")]
    public class PlayerScriptableObject :UnityEngine.ScriptableObject
    {
        public List<PlayerAttr> playerAttrs = new ();
    }
}