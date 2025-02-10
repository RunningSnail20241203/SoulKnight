using System;
using Attribute;

namespace Property.ShareProperty
{
    [Serializable]
    public class CharacterAttr
    {
        [ReadOnly] public int maxHp;
    }
}