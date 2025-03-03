using System;
using System.Collections.Generic;
using Attribute;

namespace Property.ShareProperty
{
    [Serializable]
    public class PlayerShareAttr : CharacterShareAttr
    {
        [ReadOnly] public PlayerType type;
        [ReadOnly] public PlayerSkinType defaultSkin; // 默认皮肤
        [ReadOnly] public List<PlayerSkinType> skinTypes; // 皮肤列表
        [ReadOnly] public PlayerWeaponType idleWeapon; // 默认武器
        [ReadOnly] public int armor; // 护甲
        [ReadOnly] public int magic; // 魔法值
        [ReadOnly] public int handleAttackDamage; // 徒手攻击伤害
        [ReadOnly] public float speed; // 移动速度
        [ReadOnly] public float fightingSpeed; // 战斗时移动速度
        [ReadOnly] public bool isIdleLeft; // 是否朝左站立
        [ReadOnly] public float armorRecoveryTime; // 护甲恢复时间间隔
        [ReadOnly] public float hurtArmorRecoveryTime; // 受到伤害时护甲恢复时间间隔
        [ReadOnly] public float hurtInvincibleTime; // 受到伤害时无敌时间
        [ReadOnly] public string playerName; // 角色名
    }
}