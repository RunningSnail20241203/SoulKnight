using System;
using Attribute;

namespace Property.ShareProperty
{
    [Serializable]
    public class CharacterShareAttr
    {
        [ReadOnly] public int maxHp;
    }
}