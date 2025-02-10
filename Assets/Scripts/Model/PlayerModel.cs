using Factory;
using Property.ScriptableObject;

namespace Model
{
    public class PlayerModel : AbstractModel
    {
        private PlayerScriptableObject _attr;
        public PlayerModel()
        {
             var task = ResourceFactory.Instance.GetData<PlayerScriptableObject>("PlayerData");
             task.GetAwaiter().OnCompleted(() =>
             {
                 _attr = task.Result;
             });
        }
    }
}