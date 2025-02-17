using Factory;
using Property.ScriptableObject;
using Property.ShareProperty;

namespace Model
{
    public class WeaponModel : AbstractModel
    {
        private PlayerWeaponSo _attr;

        public override bool IsInited => _attr != null;

        public WeaponModel()
        {
            var task = ResourceFactory.Instance.GetDef<PlayerWeaponSo>(PlayerWeaponSo.FileName);
            task.GetAwaiter().OnCompleted(() =>
            {
                _attr = task.Result;
            });
        }

        public PlayerWeaponShareShareAttr GetPlayerWeaponAttr(PlayerWeaponType weaponType)
        {
            return _attr.GetPlayerWeaponAttr(weaponType);
        }
    }
}