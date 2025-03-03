#region 角色相关

public enum PlayerType
{
    None,
    Knight,
    Rogue,
}

public enum PlayerSkinType
{
    None,
    Knight = 100,
    KnightLava,
    Rogue = 200,
    RogueKun,
    Wizard = 300,
    Assassin = 400,
    Alchemist = 500,
    Engineer = 600,
    Vampire = 700,
}

public enum EnemyType
{
    Boar,
    DireBoar,
    GoblinGuard,
    EliteGoblinGuard,
    GoblinShaman,
    TrumpetFlower,
    GunShark,
    GoblinGiant,
    Stake
}

#endregion


#region 武器相关

public enum PlayerWeaponType
{
    None,
    BadPistol,
    Ak47,
}

public enum EnemyWeaponType
{
    None,
    Handgun,
    Pike,
    Bow,
    Shotgun,
    Blowpipe,
    Hoe,
    GoblinMagicStaff,
    Hammer,
}

public enum WeaponCategory
{
    Pistol,
    Gun,
}

public enum PlayerBulletType
{
    Bullet5,
}

#endregion

#region 宠物相关

public enum PetType
{
    None,
    LittlePool,
    MoreMoney,
}

#endregion


#region 道具相关

public enum ItemQualityType
{
    Gray,
    White,
    Green,
    Blue,
    Purple,
    Orange,
    Red,
}

#endregion