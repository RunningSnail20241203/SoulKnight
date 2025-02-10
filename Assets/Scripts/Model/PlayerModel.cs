using Factory;
using Property.ScriptableObject;
using Property.ShareProperty;

namespace Model
{
    public class PlayerModel : AbstractModel
    {
        private PlayerScriptableObject _attr;

        public override bool IsInited => _attr != null;
        
        public PlayerModel()
        {
            var task = ResourceFactory.Instance.GetData<PlayerScriptableObject>("PlayerData");
            task.GetAwaiter().OnCompleted(() =>
            {
                _attr = task.Result;
            });
        }

        public PlayerAttr GetPlayerAttr(PlayerType playerType)
        {
            return _attr.GetPlayerAttr(playerType);
        }
    }
}