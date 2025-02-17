using System.Collections.Generic;
using Property.ShareProperty;
using UnityEngine;
using Utility;

namespace Property.ScriptableObject
{
    [CreateAssetMenu(fileName = FileName, menuName = "ScriptableObject/PetDef")]
    public class PetDataSo: UnityEngine.ScriptableObject
    {
        public const string FileName = "PetDef";
        public List<PetShareAttr> petAttrs = new();
        public TextAsset textAsset;

        private void OnValidate()
        {
            UnityTool.Instance.WriteDataToList(petAttrs, textAsset);
        }

        public PetShareAttr GetPetAttr(PetType playerType)
        {
            return petAttrs.Find(attr => attr.type == playerType);
        }
    }
}