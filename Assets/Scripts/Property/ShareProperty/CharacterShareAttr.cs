﻿using System;
using Attribute;

namespace Property.ShareProperty
{
    [Serializable]
    public class CharacterShareAttr :AbstractShareAttr
    {
        [ReadOnly] public int maxHp;
    }
}