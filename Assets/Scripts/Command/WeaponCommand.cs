using Model;
using Property.ShareProperty;
using Singleton;

namespace Command
{
    public class WeaponCommand : Singleton<WeaponCommand>
    {
        public PlayerWeaponShareAttr GetAttr(PlayerWeaponType weaponType)
        {
            var playerModel = ModelContainer.Instance.GetModel<WeaponModel>();
            return playerModel.GetAttr(weaponType);
        }
    }
}