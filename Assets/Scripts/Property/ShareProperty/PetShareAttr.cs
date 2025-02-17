using System;
using Attribute;

namespace Property.ShareProperty
{
    [Serializable]
    public class PetShareAttr : CharacterShareAttr
    {
        [ReadOnly] public PetType type;
        [ReadOnly] public int speed;
        [ReadOnly] public bool isIdleLeft;
        [ReadOnly] public string petName;
    }
}