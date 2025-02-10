using System;
using System.Collections.Generic;
using Attribute;
using Factory;

namespace Property.ShareProperty
{
    [Serializable]
    public class PlayerAttr : CharacterAttr
    {
        [ReadOnly] public PlayerType type;
        [ReadOnly] public PlayerSkinType defaultSkin;
        [ReadOnly] public List<PlayerSkinType> skinTypes;
        [ReadOnly] public PlayerWeaponType idleWeapon;
        [ReadOnly] public int armor;
        [ReadOnly] public int magic;
        [ReadOnly] public int handleAttackDamage;
        [ReadOnly] public float speed;
        [ReadOnly] public float fightingSpeed;
        [ReadOnly] public bool isIdleLeft;
        [ReadOnly] public float armorRecoveryTime;
        [ReadOnly] public float hurtArmorRecoveryTime;
        [ReadOnly] public float hurtInvincibleTime;
        [ReadOnly] public string playerName;
    }
}