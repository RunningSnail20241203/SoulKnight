using System.Collections.Generic;
using Property.ShareProperty;
using UnityEngine;
using Utility;

namespace Property.ScriptableObject
{
    [CreateAssetMenu(fileName = "EnemyDef", menuName = "ScriptableObject/EnemyDef")]
    public class EnemyDataSo : UnityEngine.ScriptableObject
    {
        public List<EnemyShareAttr> attrs;
        public TextAsset textAsset;

        private void OnValidate()
        {
            UnityTool.Instance.WriteDataToList(attrs, textAsset);
        }
        
        public EnemyShareAttr GetAttr(EnemyType type)
        {
            return attrs.Find(attr => attr.type == type);
        }
    }
}