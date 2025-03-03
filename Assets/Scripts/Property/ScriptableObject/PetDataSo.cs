using System.Collections.Generic;
using Property.ShareProperty;
using UnityEngine;
using Utility;

namespace Property.ScriptableObject
{
    [CreateAssetMenu(fileName = FileName, menuName = "ScriptableObject/PetDef")]
    public class PetDataSo : UnityEngine.ScriptableObject
    {
        public const string FileName = "PetDef";
        public List<PetShareAttr> attrs;
        public TextAsset textAsset;

        private void OnValidate()
        {
            UnityTool.Instance.WriteDataToList(attrs, textAsset);
        }

        public PetShareAttr GetAttr(PetType type)
        {
            return attrs.Find(attr => attr.type == type);
        }
    }
}