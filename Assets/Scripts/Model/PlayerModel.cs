using Factory;
using Property.ScriptableObject;
using Property.ShareProperty;

namespace Model
{
    public class PlayerModel : AbstractModel
    {
        private PlayerDataSo _attr;

        public override bool IsInited => _attr != null;
        
        public PlayerModel()
        {
            var task = ResourceFactory.Instance.GetDef<PlayerDataSo>(PlayerDataSo.FileName);
            task.GetAwaiter().OnCompleted(() =>
            {
                _attr = task.Result;
            });
        }

        public PlayerShareAttr GetPlayerAttr(PlayerType playerType)
        {
            return _attr.GetAttr(playerType);
        }
    }
}